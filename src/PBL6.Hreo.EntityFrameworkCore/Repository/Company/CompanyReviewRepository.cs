using PBL6.Hreo.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class CompanyReviewRepository : EfCoreRepository<IHreoDbContext, CompanyReview, Guid>, ICompanyReviewRepository
    {
        public CompanyReviewRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
