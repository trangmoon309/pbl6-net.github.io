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
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;
using Volo.Abp.Users;

namespace PBL6.Hreo.Services
{
    public class PostAppService : CrudAppService<
            Post,
            PostResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            PostRequest,
            PostRequest>, IPostAppService
    {
        private readonly IPostRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IPostTestRepository _postTestRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IUserInformationRepository _userInforRepository;
        private readonly IInterestedPostRepository _interestedPostRepository;

        public PostAppService(IPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IPostTestRepository postTestRepository,
            ICurrentUser currentUser,
            IUserInformationRepository userInforRepository, 
            IInterestedPostRepository interestedPostRepository) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _postTestRepository = postTestRepository;
            _currentUser = currentUser;
            _userInforRepository = userInforRepository;
            _interestedPostRepository = interestedPostRepository;
        }

        public async Task<PagedResultDto<PostResponse>> GetListByCondittion(SearchPostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var query = _repository.GetList();
                var userInformations = await _asyncQueryableExecuter.ToListAsync(_userInforRepository.GetList());
                var userInformationResponses = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(userInformations);
                var interestedPost = new List<InterestedPost>();

                query = query.OrderByDescending(x => x.CreationTime);

                if (request.Status.HasValue)
                {
                    query = query.Where(x => x.PostStatus == request.Status.Value);
                }

                if (request.IsHidden.HasValue)
                {
                    query = query.Where(x => x.IsHidden == request.IsHidden.Value);
                }

                if (!request.KeyWord.IsNullOrEmpty())
                {
                    query = query.Where(x => x.Title.ToLower().Contains(request.KeyWord.ToLower()));
                }

                var total = query.Count();

                query = query.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount);

                var toList = await _asyncQueryableExecuter.ToListAsync(query);

                var items = ObjectMapper.Map<List<Post>, List<PostResponse>>(toList);

                if (request.ApplicantId.HasValue)
                {
                    interestedPost = await _asyncQueryableExecuter.ToListAsync(_interestedPostRepository.GetList());
                    interestedPost = interestedPost.Where(x => x.ApplicantId == request.ApplicantId.Value).ToList();
                }

                items.ForEach(x =>
                {
                    if (x.CreatorId != null)
                    {
                        x.Branch = userInformationResponses.FirstOrDefault(y => y.UserId == x.CreatorId).Branch;
                    }

                    if (request.ApplicantId.HasValue)
                    {
                        x.IsFavorite = interestedPost.FirstOrDefault(y => y.PostId == x.Id) != null ? true : false;
                    }
                });

                return new PagedResultDto<PostResponse>(total, items);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<PostResponse> CreateAsync(PostRequest input)
        {
            var result = await base.CreateAsync(input);

            foreach(var item in input.TestIds)
            {
                await _postTestRepository.InsertAsync(new PostTest
                {
                    PostId = result.Id,
                    TestId = item
                });
            }

            result.CreatorId = _currentUser.Id;

            return result;
        }

        public override async Task<PostResponse> GetAsync(Guid id)
        {
            var x = await _repository.GetById(id);

            return ObjectMapper.Map<Post, PostResponse>(x);
        }

        public override async Task<PostResponse> UpdateAsync(Guid id, PostRequest input)
        {
            var updatedPost = await _repository.GetById(id);

            _postTestRepository.DeleteByPostId(id);
            updatedPost.PostTests.Clear();

            MapToEntity(input, updatedPost);

            var postTests = new List<PostTestResponse>();
            foreach (var item in input.TestIds)
            {
                var createdPostTest = await _postTestRepository.InsertAsync(new PostTest
                {
                    PostId = id,
                    TestId = item
                });
                postTests.Add(ObjectMapper.Map<PostTest, PostTestResponse>(createdPostTest));
            }

            await _repository.UpdateAsync(updatedPost);

            var result = ObjectMapper.Map<Post, PostResponse>(updatedPost);
            result.PostTests = postTests;
            return result;
        }

        public async Task<PostResponse> HiddenPost(Guid id)
        {
            try
            {
                var updatedPost = await _repository.GetById(id);
                updatedPost.IsHidden = true;

                await _repository.UpdateAsync(updatedPost);

                return ObjectMapper.Map<Post, PostResponse>(updatedPost);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
