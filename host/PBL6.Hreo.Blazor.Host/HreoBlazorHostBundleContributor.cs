using Volo.Abp.Bundling;

namespace PBL6.Hreo.Blazor.Host
{
    public class HreoBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
