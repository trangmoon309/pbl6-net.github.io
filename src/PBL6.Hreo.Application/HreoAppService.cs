using PBL6.Hreo.Localization;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo
{
    public abstract class HreoAppService : ApplicationService
    {
        protected HreoAppService()
        {
            LocalizationResource = typeof(HreoResource);
            ObjectMapperContext = typeof(HreoApplicationModule);
        }
    }
}
