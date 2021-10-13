using PBL6.Hreo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PBL6.Hreo.Pages
{
    public abstract class HreoPageModel : AbpPageModel
    {
        protected HreoPageModel()
        {
            LocalizationResourceType = typeof(HreoResource);
        }
    }
}