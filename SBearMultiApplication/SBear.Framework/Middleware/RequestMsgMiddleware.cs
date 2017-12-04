using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SBear.Service.SBear.ISBearService;

namespace SBear.Framework.Middleware
{
    public class RequestMsgMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog _log;
        private readonly ISBearVisitorLogService _iSBearVisitorLogService;


        public RequestMsgMiddleware(RequestDelegate next, ILog log, ISBearVisitorLogService iSBearVisitorLogService)
        {
            _next = next;
            _log = log;
            _iSBearVisitorLogService = iSBearVisitorLogService;
        }
        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToString();
            if (!(url.Contains("/css") || url.Contains("/js") || url.Contains("/images") || url.Contains("/lib")))
            {
                _log.Info($"Url:{url} IP:{context.Connection.RemoteIpAddress} 时间：{DateTime.Now}");
                //_iSBearVisitorLogService.Insert(context.Connection.RemoteIpAddress.ToString());
            }
            await _next(context);
        }
    }
}
