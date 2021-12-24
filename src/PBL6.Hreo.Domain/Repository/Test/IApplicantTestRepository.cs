using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IApplicantTestRepository : IRepository<ApplicantTest, Guid>
    {
        Task<ApplicantTest> GetById(Guid id);

        IQueryable<ApplicantTest> GetList();
    }
}
