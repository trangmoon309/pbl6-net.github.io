using Microsoft.Extensions.DependencyInjection;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Repository;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PBL6.Hreo.EntityFrameworkCore
{
    [DependsOn(
        typeof(HreoDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class HreoEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HreoIdentityDbContext>(options =>
            {
                options.AddRepository<User, UserRepository>();
                options.AddRepository<UserRole, UserRoleRepository>();
            });
        }
    }
}