using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HreoHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Hreo";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HreoApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
