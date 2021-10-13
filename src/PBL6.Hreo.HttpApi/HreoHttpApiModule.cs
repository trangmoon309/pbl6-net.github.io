using Localization.Resources.AbpUi;
using PBL6.Hreo.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HreoHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HreoHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HreoResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
