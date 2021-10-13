using PBL6.Hreo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PBL6.Hreo.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HreoPageModel : AbpPageModel
    {
        protected HreoPageModel()
        {
            LocalizationResourceType = typeof(HreoResource);
            ObjectMapperContext = typeof(HreoWebModule);
        }
    }
}