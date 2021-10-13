using PBL6.Hreo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PBL6.Hreo
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(HreoEntityFrameworkCoreTestModule)
        )]
    public class HreoDomainTestModule : AbpModule
    {
        
    }
}
