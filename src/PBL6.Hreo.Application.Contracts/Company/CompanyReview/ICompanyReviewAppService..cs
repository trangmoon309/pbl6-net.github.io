using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace PBL6.Hreo.Services
{
    public interface ICompanyReviewAppService : ICrudAppService<
                CompanyReviewResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                CompanyReviewRequest,
                CompanyReviewRequest>
    {
    }
}
