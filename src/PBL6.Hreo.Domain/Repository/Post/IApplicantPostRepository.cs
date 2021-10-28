using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IApplicantPostRepository : IRepository<ApplicantPost, Guid>
    {
        Task CreateMultiple(List<ApplicantPost> appPosts);

        IQueryable<ApplicantPost> GetListByApplicantId(Guid appId);

        IQueryable<ApplicantPost> GetList();
    }
}
