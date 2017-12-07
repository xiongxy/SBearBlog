using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Framework
{
    public class SBearHttpContext
    {
        public static IServiceProvider ServiceProvider;
        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                if (ServiceProvider == null)
                {
                    Console.Write("ServiceProvider is Null");
                    return null;
                }
                object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
                if (factory == null)
                {
                    Console.Write("factory is Null");
                    return null;
                }
                Microsoft.AspNetCore.Http.HttpContext context = ((Microsoft.AspNetCore.Http.HttpContextAccessor)factory).HttpContext;
                return context;
            }
        }
    }
}
