using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoApplicationModule),
        typeof(HreoDomainTestModule)
        )]
    public class HreoApplicationTestModule : AbpModule
    {

    }
}
