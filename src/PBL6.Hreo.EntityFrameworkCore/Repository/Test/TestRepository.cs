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
    public class TestRepository : EfCoreRepository<IHreoDbContext, Test, Guid>, ITestRepository
    {
        public TestRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Test> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => !x.IsDeleted && x.Id.Equals(id))
                .Include(x => x.TestQuestions)
                .FirstOrDefaultAsync();
            return query;
        }

        public IQueryable<Test> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted)
                .Include(x => x.TestQuestions);
        }
    }
}
