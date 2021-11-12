using Greenglobal.Erp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Greenglobal.Erp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ErpAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));

            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                result = false;
            }

            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;

                try
                {
                    var claims = tokenManager.VerifyToken(token);
                }
                catch (Exception e)
                {
                    var user = context.HttpContext.User;

                    if (!user.Identity.IsAuthenticated)
                    {
                        result = false;
                        context.ModelState.AddModelError("Unauthorized", "You are not authorized");
                    }
                }
            }

            if (!result)
            {
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
