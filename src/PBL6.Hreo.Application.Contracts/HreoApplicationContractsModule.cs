using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class HreoApplicationContractsModule : AbpModule
    {

    }
}
