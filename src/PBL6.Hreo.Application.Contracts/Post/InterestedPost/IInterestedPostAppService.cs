using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Services
{
    public interface IInterestedPostAppService : ICrudAppService<
                InterestedPostResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                InterestedPostRequest,
                InterestedPostRequest>
    {
        Task<PagedResultDto<InterestedPostResponse>> GetListByCondittion(SearchInterestPostRequest request, PagedAndSortedResultRequestDto pageRequest);

        Task<InterestedPostResponse> UpdateStatus(Guid id, InterestedPostStatus status);

        Task DeleteByContidion(Guid applicantId, Guid postId);
    }
}
