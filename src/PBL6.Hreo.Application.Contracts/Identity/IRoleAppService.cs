using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBL6.Hreo.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IRoleAppService :
        ICrudAppService<
            RoleResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            RoleRequest,
            RoleRequest>
    {
        Task<PagedResultDto<RoleResponse>> GetListAsync(string filter, PagedResultRequestDto input);

        Task<List<RoleResponse>> GetAllAsync();

        List<string> GetRoleCodes();
    }
}