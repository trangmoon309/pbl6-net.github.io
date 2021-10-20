using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.EntityFrameworkCore
{
    [ConnectionStringName("Default")]

    public interface IHreoIdentityDbContext : IEfCoreDbContext
    {
        DbSet<User> AbpUsers { get; set; }

        DbSet<Role> AbpRoles { get; set; }

        DbSet<UserRole> AbpUserRoles { get; set; }
    }
}
