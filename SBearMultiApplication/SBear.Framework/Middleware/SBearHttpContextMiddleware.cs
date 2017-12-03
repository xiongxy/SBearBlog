using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBear.Framework.Middleware
{
    public class SBearHttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        public SBearHttpContextMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }
        public async Task Invoke(HttpContext context)
        {
            SBearHttpContext.ServiceProvider = _serviceProvider;
            await _next(context);
        }
    }
}
