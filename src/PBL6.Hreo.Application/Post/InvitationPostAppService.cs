using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Services
{
    public class InvitationPostAppService : CrudAppService<
            InvitationPost,
            InvitationPostResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            InvitationPostRequest,
            InvitationPostRequest>, IInvitationPostAppService
    {
        private readonly IInvitationPostRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IPostRepository _postRepository;
        private readonly IUserInformationRepository _userInforRepository;
        private readonly IUserInformationAppService _userInforAppService;
        private readonly IUserRepository _userRepository;
        private readonly INotificationUserAppService _notification;
        private readonly IDeviceRepository _device;

        public InvitationPostAppService(IInvitationPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IPostRepository postRepository,
            IUserInformationRepository userInforRepository,
            IUserInformationAppService userInforAppService,
            IUserRepository userRepository,
            INotificationUserAppService notification, 
            IDeviceRepository device) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _postRepository = postRepository;
            _userInforRepository = userInforRepository;
            _userInforAppService = userInforAppService;
            _userRepository = userRepository;
            _notification = notification;
            _device = device;
        }

        // Xem danh sách thí sinh đủ điều kiện của bài post để HR xem và mời
        public async Task<PagedResultDto<UserInformationResponse>> GetListByCondittion(Guid postId, SearchInvitePostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var post = await _postRepository.GetById(postId);
                var userInfors = _userInforRepository.GetList().Where(x => x.Language.Equals(post.Language)
                                  && x.Level.Equals(post.Level));

                var userIds = userInfors.Select(x => x.Id);

                var userIdList = await _asyncQueryableExecuter.ToListAsync(userIds);

                var query = _repository.GetList();

                query = query.Where(x => x.PostId.Equals(postId) && userIdList.Contains(x.ApplicantId)).OrderByDescending(x => x.CreationTime);

                if (request.Status.HasValue) query = query.Where(x => x.InvitationPostStatus == request.Status.Value);

                if (request.Level.HasValue) query = query.Where(x => x.Applicant.Level.ToString() == request.Level.Value.ToString());


                var userList = await _asyncQueryableExecuter.ToListAsync(userInfors);
                var total = userList.Count();
                var result = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(userList);

                var userAbp = await _userRepository.GetList();
                var userAbpList = await _asyncQueryableExecuter.ToListAsync(userAbp);
                var userAbpResponse = ObjectMapper.Map<List<User>, List<UserResponse>>(userAbpList);

                result = result.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount).ToList();

                result.ForEach(x =>
                {
                    x.UserAbp = userAbpResponse.FirstOrDefault(y => y.Id.Equals(x.UserId));
                    if (query != null)
                    {
                        var invited = query.FirstOrDefault(y => y.ApplicantId.Equals(x.Id));
                        if (invited != null) x.IsInvitedForPost = invited.InvitationPostStatus;
                        else x.IsInvitedForPost = InvitationPostStatus.NOT_INVITED_YET;
                    }
                    else x.IsInvitedForPost = InvitationPostStatus.NOT_INVITED_YET;
                });

                return new PagedResultDto<UserInformationResponse>(total, result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Xem danh sách lời mời của 1 applicant
        public async Task<List<InvitationPostResponse>> GetListByApplicantIdCondittion(Guid applicantId)
        {
            try
            {

                var query = _repository.GetList();

                query = query.Where(x => x.ApplicantId.Equals(applicantId)).OrderByDescending(x => x.CreationTime);

                var toList = await _asyncQueryableExecuter.ToListAsync(query);
                var result = ObjectMapper.Map<List<InvitationPost>, List<InvitationPostResponse>>(toList);
                var applicant = await _userInforAppService.GetByUserInforId(applicantId);
                var users = await _asyncQueryableExecuter.ToListAsync(_userInforRepository.GetList());
                var userResponses = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(users);

                result.ForEach(x =>
                {
                    if(x.Applicant == null)
                    {
                        x.Applicant = new UserInformationResponse();
                        x.Applicant = applicant;
                    }
                    else
                    {
                        x.Applicant.UserAbp = applicant.UserAbp;
                    }

                    x.Post.Creator = userResponses.FirstOrDefault(y => y.Id.Equals(x.Post.CreatorId));
                });

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // B2: Send-notification
        // Nếu Thí sinh chấp nhận thì update status
        public async Task<List<InvitationPostResponse>> CreateMultiple(List<InvitationPostRequest> request)
        {
            try
            {

                var entities = ObjectMapper.Map<List<InvitationPostRequest>, List<InvitationPost>>(request);

                var userAbp = await _userRepository.GetList();
                var userAbpList = await _asyncQueryableExecuter.ToListAsync(userAbp);
                var userAbpResponse = ObjectMapper.Map<List<User>, List<UserResponse>>(userAbpList);
                var devices = await _device.GetListAsync();

                entities.ForEach(x => {
                    EntityHelper.TrySetId(x, GuidGenerator.Create);
                    x.InvitationPostStatus = InvitationPostStatus.WAITING;
                });

                await _repository.CreateMultiple(entities);

                var responses = ObjectMapper.Map<List<InvitationPost>, List<InvitationPostResponse>>(entities);

                var post = await _postRepository.GetById(request.First().PostId);
                var postResponse = ObjectMapper.Map<Post, PostResponse>(post);
                var userInfors = _userInforRepository.GetList().ToList();
                var userInforResponse = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(userInfors);

                  var notificationUsers = new List<PushNotificationRequest>();
                var title = string.Empty;
                var language = string.Empty;
                var level = string.Empty;
                responses.ForEach(x =>
                {
                    x.Post = postResponse;
                    x.Applicant = userInforResponse.FirstOrDefault(y => y.Id.Equals(x.ApplicantId));
                    x.Applicant.UserAbp = userAbpResponse.FirstOrDefault(y => y.Id.Equals(x.Applicant.UserId));

                    if(title == string.Empty) title = x.Post.Title;
                    if (language == string.Empty) language = x.Post.Language.ToString();
                    if (level == string.Empty) level = x.Post.Level.ToString();
                });

                if (notificationUsers.Any())
                {
                    await _notification.SendNotification(notificationUsers);

                    var deviceUser = devices.FirstOrDefault();

                    if (deviceUser != null)
                    {
                        notificationUsers.Add(new PushNotificationRequest
                        {
                            to = deviceUser.DeviceToken,
                            title = "Bạn có lời mời ứng tuyển mới, hãy xem thử nhé!!",
                            subtitle = language + "-" + level,
                            body = title.Substring(0, 50) + "..."
                        });
                    }
                }

                await _notification.SendEmailNotification(title);

                return responses;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<List<InvitationPostResponse>> CreateMultiple2(InvitationPostRequest2 request)
        {
            try
            {
                var userAbp = await _userRepository.GetList();
                var userAbpList = await _asyncQueryableExecuter.ToListAsync(userAbp);
                var userAbpResponse = ObjectMapper.Map<List<User>, List<UserResponse>>(userAbpList);
                var devices = await _device.GetListAsync();

                var entities = new List<InvitationPost>();
                foreach (var item in request.ApplicantIds)
                {
                    var itemEntity = new InvitationPost()
                    {
                        ApplicantId = item,
                        PostId = request.PostId,
                        InvitationPostStatus = InvitationPostStatus.WAITING
                    };
                    EntityHelper.TrySetId(itemEntity, GuidGenerator.Create);

                    entities.Add(itemEntity);
                }

                await _repository.CreateMultiple(entities);

                var responses = ObjectMapper.Map<List<InvitationPost>, List<InvitationPostResponse>>(entities);

                var post = await _postRepository.GetById(request.First().PostId);
                var postResponse = ObjectMapper.Map<Post, PostResponse>(post);
                var userInfors = _userInforRepository.GetList().ToList();
                var userInforResponse = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(userInfors);

                var notificationUsers = new List<PushNotificationRequest>();
                var title = string.Empty;
                var language = string.Empty;
                var level = string.Empty;
                responses.ForEach(x =>
                {
                    x.Post = postResponse;
                    x.Applicant = userInforResponse.FirstOrDefault(y => y.Id.Equals(x.ApplicantId));
                    x.Applicant.UserAbp = userAbpResponse.FirstOrDefault(y => y.Id.Equals(x.Applicant.UserId));

                    if (title == string.Empty) title = x.Post.Title;
                    if (language == string.Empty) language = x.Post.Language.ToString();
                    if (level == string.Empty) level = x.Post.Level.ToString();
                });

                if (notificationUsers.Any())
                {
                    await _notification.SendNotification(notificationUsers);

                    var deviceUser = devices.FirstOrDefault();

                    if (deviceUser != null)
                    {
                        notificationUsers.Add(new PushNotificationRequest
                        {
                            to = deviceUser.DeviceToken,
                            title = "Bạn có lời mời ứng tuyển mới, hãy xem thử nhé!!",
                            subtitle = language + "-" + level,
                            body = title.Substring(0, 50) + "..."
                        });
                    }
                }

                await _notification.SendEmailNotification(title);

                return responses;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<InvitationPostResponse> UpdateStatus(Guid id, InvitationPostStatus status)
        {
            try
            {
                var updatedPost = await _repository.GetById(id);
                updatedPost.InvitationPostStatus = status;

                await _repository.UpdateAsync(updatedPost);

                return ObjectMapper.Map<InvitationPost, InvitationPostResponse>(updatedPost);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
