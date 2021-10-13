using PBL6.Hreo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace PBL6.Hreo.Blazor.Server.Host
{
    public abstract class HreoComponentBase : AbpComponentBase
    {
        protected HreoComponentBase()
        {
            LocalizationResource = typeof(HreoResource);
        }
    }
}
