using Greenglobal.Erp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo.Localization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace PBL6.Hreo
{
    //[IgnoreAntiforgeryToken]
    //[ErpAuthorizationFilter]
    //[RemoteService]
    public abstract class HreoController : AbpController
    {
        protected HreoController() 
        {
            LocalizationResource = typeof(HreoResource);
        }
    }
}
