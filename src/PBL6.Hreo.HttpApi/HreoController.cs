using PBL6.Hreo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace PBL6.Hreo
{
    public abstract class HreoController : AbpController
    {
        protected HreoController()
        {
            LocalizationResource = typeof(HreoResource);
        }
    }
}
