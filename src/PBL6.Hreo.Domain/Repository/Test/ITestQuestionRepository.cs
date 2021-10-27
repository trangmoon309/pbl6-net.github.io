using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface ITestQuestionRepository : IRepository<TestQuestion, Guid>
    {
        IQueryable<TestQuestion> GetByTestId(Guid testId);

        void DeleteByTestId(Guid testId);
    }
}
