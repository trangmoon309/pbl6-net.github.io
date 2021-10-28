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

        public InvitationPostAppService(IInvitationPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IPostRepository postRepository, 
            IUserInformationRepository userInforRepository) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _postRepository = postRepository;
            _userInforRepository = userInforRepository;
        }

        // Xem danh sách thí sinh đủ điều kiện của bài post để HR xem và mời
        public async Task<PagedResultDto<UserInformationResponse>> GetListByCondittion(Guid postId, SearchInvitePostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var userInfors = _userInforRepository.GetList();
                var post = await _postRepository.GetById(postId);

                var userIds = userInfors.Where(x => x.Language.ToString().Equals(post.Language.ToString())
                                                  && x.Level.ToString().Equals(post.Level.ToString()))
                                        .Select(x => x.Id);

                var query = _repository.GetList();

                query = query.Where(x => x.PostId.Equals(postId) && userIds.Contains(x.ApplicantId)).OrderByDescending(x => x.CreationTime);

                if (request.Status.HasValue) query = query.Where(x => x.InvitationPostStatus == request.Status.Value);

                if (request.Level.HasValue) query = query.Where(x => x.UserInformation.Level.ToString() == request.Level.Value.ToString());


                var userList = await _asyncQueryableExecuter.ToListAsync(userInfors);
                var total = userList.Count();
                var result = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(userList);

                result = result.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount).ToList();

                result.ForEach(x =>
                {
                    var invited = query.FirstOrDefault(y => y.ApplicantId.Equals(x.Id));
                    if (invited != null) x.IsInvitedForPost = invited.InvitationPostStatus;
                    else x.IsInvitedForPost = InvitationPostStatus.NOT_INVITED_YET;
                });

                return new PagedResultDto<UserInformationResponse>(total, result);
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

                entities.ForEach(x => {
                    EntityHelper.TrySetId(x, GuidGenerator.Create);
                    x.InvitationPostStatus = InvitationPostStatus.WAITING;
                });

                await _repository.CreateMultiple(entities);

                var responses = ObjectMapper.Map<List<InvitationPost>, List<InvitationPostResponse>>(entities);

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
