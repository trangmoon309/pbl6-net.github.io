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

        public PostAppService(IPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }

        public async Task<PagedResultDto<PostResponse>> GetListByCondittion(SearchPostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var query = _repository.GetList();

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

                query = query.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount);

                var toList = await _asyncQueryableExecuter.ToListAsync(query);

                var items = ObjectMapper.Map<List<Post>, List<PostResponse>>(toList);
                var total = items.Count();

                return new PagedResultDto<PostResponse>(total, items);
            }
            catch (Exception e)
            {
                throw e;
            }
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
