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
    public class ApplicantTestQuestionRepository : EfCoreRepository<IHreoDbContext, ApplicantTestQuestion, Guid>, IApplicantTestQuestionRepository
    {
        public ApplicantTestQuestionRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ApplicantTestQuestion> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => x.Id.Equals(id))
                .Include(x => x.ApplicantTest)
                .Include(x => x.TestQuestion)
                .FirstOrDefaultAsync();
            return query;
        }

        public IQueryable<ApplicantTestQuestion> GetList()
        {
            return GetQueryable()
                .Include(x => x.ApplicantTest)
                .Include(x => x.TestQuestion);
        }
    }
}
