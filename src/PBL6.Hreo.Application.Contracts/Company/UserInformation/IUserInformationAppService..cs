using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IUserInformationAppService : ICrudAppService<
                UserInformationResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                UserInformationRequest,
                UserInformationRequest>
    {
        Task<UserInformationResponse> GetByUserId(Guid userId);

        Task<UserInformationResponse> GetCurrentUserInformation();

        Task<UserInformationResponse> GetByUserInforId(Guid userId);
    }
}
