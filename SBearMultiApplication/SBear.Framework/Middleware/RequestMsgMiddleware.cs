using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SBear.Framework.Middleware
{
    public class RequestMsgMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _log;
        public RequestMsgMiddleware(RequestDelegate next, ILog log)
        {
            _next = next;
            _log = log;
        }
        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToString();
            if (!(url.Contains("/css") || url.Contains("/js") || url.Contains("/images") || url.Contains("/lib")))
            {
                _log.Info($"Url:{url} IP:{context.Connection.RemoteIpAddress.ToString()} 时间：{DateTime.Now}");
            }
            await _next(context);
        }
    }
}
