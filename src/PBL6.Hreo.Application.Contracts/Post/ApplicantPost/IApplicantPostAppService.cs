using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IApplicantPostAppService : ICrudAppService<
                ApplicantPostResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                ApplicantPostRequest,
                ApplicantPostRequest>
    {
        Task<List<ApplicantPostResponse>> CreateMultiple(List<SendTestToApplicationRequest> request);

        Task<PagedResultDto<UserInformationResponse>> GetSubmitedListByCondittion(Guid postId, SearchInvitePostRequest request, PagedAndSortedResultRequestDto pageRequest);

        Task<PagedResultDto<ApplicantPostResponse>> GetListByApplicant(Guid applicantId, SearchAppTestRequest request, PagedAndSortedResultRequestDto pageRequest);
    }
}
