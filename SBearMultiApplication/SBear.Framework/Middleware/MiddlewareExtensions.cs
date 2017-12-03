using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Microsoft.AspNetCore.Builder;

namespace SBear.Framework.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMsgMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMsgMiddleware>(LogManager.GetLogger("NETCoreRepository", ""));
        }
        public static IApplicationBuilder UseSBearHttpContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SBearHttpContextMiddleware>();
        }
    }
}
