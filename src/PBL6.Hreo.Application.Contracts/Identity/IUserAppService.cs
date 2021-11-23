using PBL6.Hreo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IUserAppService :
        ICrudAppService<
            UserResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            UserRequest,
            UserRequest>
    {
        Task<PagedResultDto<UserResponse>> GetListAsync(SearchUserRequest searchRequest, PagedAndSortedResultRequestDto pageRequest);

        Task<UserResponse> GetCurrentUser();

        Task<UserResponse> SignUpCustom(UserRequest request);
    }
}