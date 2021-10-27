using PBL6.Hreo.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using System.Linq;

namespace PBL6.Hreo.Repository
{
    public class TestQuestionRepository : EfCoreRepository<IHreoDbContext, TestQuestion, Guid>, ITestQuestionRepository
    {
        public TestQuestionRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<TestQuestion> GetByTestId(Guid testId)
        {
            var query = GetQueryable().Where(x => !x.IsDeleted && x.TestId.Equals(testId));
            return query;
        }

        public void DeleteByTestId(Guid testId)
        {
            var query = GetQueryable().Where(x => !x.IsDeleted && x.TestId.Equals(testId));
            DbContext.TestQuestions.RemoveRange(query);
        }
    }
}
