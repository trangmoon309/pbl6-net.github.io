using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(HreoDomainSharedModule)
    )]
    public class HreoDomainModule : AbpModule
    {

    }
}
