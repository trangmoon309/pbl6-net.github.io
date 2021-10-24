using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;

namespace PBL6.Hreo
{
    [DependsOn(
        typeof(HreoDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpBlobStoringModule),
        typeof(AbpBlobStoringFileSystemModule)
        )]
    public class HreoApplicationContractsModule : AbpModule
    {

    }
}
