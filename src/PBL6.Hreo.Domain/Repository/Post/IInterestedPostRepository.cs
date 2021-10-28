using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IInterestedPostRepository : IRepository<InterestedPost, Guid>
    {
        IQueryable<InterestedPost> GetList();

        Task<InterestedPost> GetById(Guid id);

        IQueryable<InterestedPost> GetByPostId(Guid postId);
    }
}
