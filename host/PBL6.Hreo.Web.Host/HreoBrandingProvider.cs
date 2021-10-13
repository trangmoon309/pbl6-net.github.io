using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PBL6.Hreo
{
    [Dependency(ReplaceServices = true)]
    public class HreoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Hreo";
    }
}
