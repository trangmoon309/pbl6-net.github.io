using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class UserRoleRepository : EfCoreRepository<HreoIdentityDbContext, UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<HreoIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
