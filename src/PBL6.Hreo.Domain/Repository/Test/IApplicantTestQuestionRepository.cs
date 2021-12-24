using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IApplicantTestQuestionRepository : IRepository<ApplicantTestQuestion, Guid>
    {
        Task<ApplicantTestQuestion> GetById(Guid id);

        IQueryable<ApplicantTestQuestion> GetList();
    }
}
