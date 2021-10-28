using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class ApplicantPostRepository : EfCoreRepository<IHreoDbContext, ApplicantPost, Guid>, IApplicantPostRepository
    {
        public ApplicantPostRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task CreateMultiple(List<ApplicantPost> appPosts)
        {
            await DbContext.ApplicantPosts.AddRangeAsync(appPosts);
        }

        public IQueryable<ApplicantPost> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted)
                .Include(x => x.Post)
                .Include(x => x.UserInformation);
        }

        public IQueryable<ApplicantPost> GetListByApplicantId(Guid appId)
        {
            return GetQueryable().Where(x => !x.IsDeleted && x.ApplicantId.Equals(appId))
                .Include(x => x.Post)
                .Include(x => x.UserInformation);
        }
    }
}
