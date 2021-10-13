using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace PBL6.Hreo.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(HreoBlazorModule)
        )]
    public class HreoBlazorServerModule : AbpModule
    {
        
    }
}