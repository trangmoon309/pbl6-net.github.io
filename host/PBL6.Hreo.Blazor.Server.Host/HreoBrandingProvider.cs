using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace PBL6.Hreo.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class HreoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hreo";
    }
}
