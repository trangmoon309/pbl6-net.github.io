using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class HreoConsoleApiClientModule : AbpModule
    {
        
    }
}
