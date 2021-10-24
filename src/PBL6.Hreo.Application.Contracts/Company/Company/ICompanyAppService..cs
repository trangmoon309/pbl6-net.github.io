using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace PBL6.Hreo.Services
{
    public interface ICompanyAppService : ICrudAppService<
            CompanyResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            CompanyRequest,
            CompanyRequest>
    {
    }
}
