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
    public interface IInvitationPostAppService : ICrudAppService<
                InvitationPostResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                InvitationPostRequest,
                InvitationPostRequest>
    {
        Task<PagedResultDto<UserInformationResponse>> GetListByCondittion(Guid postId, SearchInvitePostRequest request, PagedAndSortedResultRequestDto pageRequest);

        Task<List<InvitationPostResponse>> CreateMultiple(List<InvitationPostRequest> request);

        Task<InvitationPostResponse> UpdateStatus(Guid id, InvitationPostStatus status);
    }
}
