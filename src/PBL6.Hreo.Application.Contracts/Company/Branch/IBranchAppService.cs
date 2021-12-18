using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace PBL6.Hreo.Services
{
    public interface IBranchAppService : ICrudAppService<
            BranchResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BranchRequest,
            BranchRequest>
    {
        Task SeedBranchData();
    }
}
