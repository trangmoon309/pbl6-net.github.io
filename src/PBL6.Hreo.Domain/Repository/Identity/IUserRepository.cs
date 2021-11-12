using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<IQueryable<User>> GetList();

        IQueryable<User> GetById(Guid id);
    }
}
