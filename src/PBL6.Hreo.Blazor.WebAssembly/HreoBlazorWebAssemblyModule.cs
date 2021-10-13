using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace PBL6.Hreo.Blazor.WebAssembly
{
    [DependsOn(
        typeof(HreoBlazorModule),
        typeof(HreoHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class HreoBlazorWebAssemblyModule : AbpModule
    {
        
    }
}