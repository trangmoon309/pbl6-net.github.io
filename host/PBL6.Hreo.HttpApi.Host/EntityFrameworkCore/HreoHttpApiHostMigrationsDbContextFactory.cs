using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PBL6.Hreo.EntityFrameworkCore
{
    public class HreoHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<HreoHttpApiHostMigrationsDbContext>
    {
        public HreoHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HreoHttpApiHostMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Hreo"));

            return new HreoHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
