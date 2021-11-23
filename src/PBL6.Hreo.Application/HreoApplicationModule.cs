using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Identity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoDomainModule),
        typeof(HreoApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpBlobStoringModule),
        typeof(AbpBlobStoringFileSystemModule),
        typeof(AbpIdentityApplicationModule)

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
