using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoDomainModule),
        typeof(HreoApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HreoApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HreoApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HreoApplicationModule>(validate: true);
            });
        }
    }
}
