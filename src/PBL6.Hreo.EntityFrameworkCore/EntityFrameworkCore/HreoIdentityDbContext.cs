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
    public class HreoIdentityDbContext : AbpDbContext<HreoIdentityDbContext>, IHreoIdentityDbContext
    {
        public HreoIdentityDbContext(DbContextOptions<HreoIdentityDbContext> options) : base(options)
        {
        }

        public DbSet<User> AbpUsers { get; set; }

        public DbSet<Role> AbpRoles { get; set; }

        public DbSet<UserRole> AbpUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasKey(table => new {
                table.RoleId,
                table.UserId
            });

            builder.ConfigureHreo();
        }
    }
}
