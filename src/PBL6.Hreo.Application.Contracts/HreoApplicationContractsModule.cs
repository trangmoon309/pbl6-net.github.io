using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Identity;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpBlobStoringModule),
        typeof(AbpBlobStoringFileSystemModule),
        typeof(AbpIdentityApplicationContractsModule)
        )]
    public class HreoApplicationContractsModule : AbpModule
    {

    }
}
