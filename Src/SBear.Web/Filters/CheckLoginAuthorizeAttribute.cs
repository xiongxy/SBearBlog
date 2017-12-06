using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SBear.Framework.Account;

namespace SBear.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckLoginAuthorizeAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!UserRuntimeContext.CheckUserLogin())
            {
                context.Result = new RedirectResult("/Login");
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
