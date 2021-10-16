
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
    public class RoleRepository : EfCoreRepository<HreoIdentityDbContext, Role, Guid>, IRoleRepository
    {
        public RoleRepository(IDbContextProvider<HreoIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IQueryable<Role>> GetList()
        {
            return await GetQueryableAsync();
        }

        public async Task<IQueryable<Role>> GetByNormalizedName(string name)
        {
            var x = await GetQueryableAsync();
            return x.Where(x => x.NormalizedName == name.ToUpper());
        }
    }
}
