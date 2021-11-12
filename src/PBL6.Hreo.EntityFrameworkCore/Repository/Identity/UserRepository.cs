
using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class UserRepository : EfCoreRepository<HreoIdentityDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<HreoIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IQueryable<User>> GetList()
        {
            var x = await GetQueryableAsync();
            return x.Include(x => x.UserRoles).ThenInclude(x => x.Role);
        }

        public IQueryable<User> GetById(Guid id)
        {
            return GetQueryable().Where(x => !x.IsDeleted && x.Id.Equals(id))
                .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                .AsNoTracking();
        }
    }
}
