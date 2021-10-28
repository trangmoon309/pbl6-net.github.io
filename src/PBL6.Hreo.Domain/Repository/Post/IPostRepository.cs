using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL6.Hreo.Entities;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        IQueryable<Post> GetList();

        Task<Post> GetById(Guid id);
    }
}
