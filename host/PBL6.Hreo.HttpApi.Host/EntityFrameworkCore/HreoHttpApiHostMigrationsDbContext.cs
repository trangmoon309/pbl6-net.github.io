using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.EntityFrameworkCore
{
    public class HreoHttpApiHostMigrationsDbContext : AbpDbContext<HreoHttpApiHostMigrationsDbContext>
    {
        public HreoHttpApiHostMigrationsDbContext(DbContextOptions<HreoHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureHreo();
        }
    }
}
