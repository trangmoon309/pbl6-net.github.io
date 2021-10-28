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
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Services
{
    public class InterestedPostAppService : CrudAppService<
            InterestedPost,
            InterestedPostResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            InterestedPostRequest,
            InterestedPostRequest>, IInterestedPostAppService
    {
        private readonly IInterestedPostRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public InterestedPostAppService(IInterestedPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }

        public async Task<PagedResultDto<InterestedPostResponse>> GetListByCondittion(SearchInterestPostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                var query = _repository.GetList();

                query = query.OrderByDescending(x => x.CreationTime);

                if (request.Status.HasValue)
                {
                    query = query.Where(x => x.InterestedPostStatus == request.Status.Value);
                }

                if (!request.KeyWord.IsNullOrEmpty())
                {
                    query = query.Where(x => x.UserInformation.Branch.Company.Name.ToLower().Contains(request.KeyWord.ToLower()));
                }

                query = query.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount);

                var toList = await _asyncQueryableExecuter.ToListAsync(query);

                var items = ObjectMapper.Map<List<InterestedPost>, List<InterestedPostResponse>>(toList);
                var total = items.Count();

                return new PagedResultDto<InterestedPostResponse>(total, items);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<InterestedPostResponse> UpdateStatus(Guid id, InterestedPostStatus status)
        {
            try
            {
                var updatedPost = await _repository.GetById(id);
                updatedPost.InterestedPostStatus = status;

                await _repository.UpdateAsync(updatedPost);

                return ObjectMapper.Map<InterestedPost, InterestedPostResponse>(updatedPost);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Loại bỏ ứng viên đã submit
        // TODO: Notification
        public async Task DeleteByContidion(Guid applicantId, Guid postId)
        {
            try
            {
                var query = _repository.GetList();

                query = query.Where(x => x.ApplicantId.Equals(applicantId) && x.PostId.Equals(postId));
                var x = await _asyncQueryableExecuter.FirstOrDefaultAsync(query);

                await _repository.DeleteAsync(x);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
