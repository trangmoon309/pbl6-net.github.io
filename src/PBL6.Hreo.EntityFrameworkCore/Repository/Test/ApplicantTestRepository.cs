using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class ApplicantTestRepository : EfCoreRepository<IHreoDbContext, ApplicantTest, Guid>, IApplicantTestRepository
    {
        public ApplicantTestRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ApplicantTest> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => x.Id.Equals(id))
                .Include(x => x.Applicant)
                .Include(x => x.Test)
                .Include(x => x.Post)
                .Include(x => x.ApplicantTestQuestions)
                .FirstOrDefaultAsync();
            return query;
        }

        public IQueryable<ApplicantTest> GetList()
        {
            return GetQueryable()
                .Include(x => x.Applicant)
                .Include(x => x.Test)
                .Include(x => x.Post)
                .Include(x => x.ApplicantTestQuestions);
        }
    }
}
