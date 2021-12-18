using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface ITestRepository : IRepository<Test, Guid>
    {
        Task<Test> GetById(Guid id);

        IQueryable<Test> GetList();

        IQueryable<Test> SearchQueryable(IQueryable<Test> query, string keyWord);
    }
}
