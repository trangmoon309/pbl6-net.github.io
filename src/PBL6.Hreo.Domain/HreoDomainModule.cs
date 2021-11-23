using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(HreoDomainSharedModule),
        typeof(AbpIdentityDomainModule)

    )]
    public class HreoDomainModule : AbpModule
    {

    }
}
