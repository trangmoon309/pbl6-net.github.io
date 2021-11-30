using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL6.Hreo.Entities;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IPostTestRepository : IRepository<PostTest, Guid>
    {
        IQueryable<PostTest> GetList();

        Task<PostTest> GetById(Guid id);

        void DeleteByPostId(Guid postId);
    }
}
