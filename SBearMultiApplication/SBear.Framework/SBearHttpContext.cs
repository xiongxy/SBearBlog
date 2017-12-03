﻿using System;
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
                object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
                Microsoft.AspNetCore.Http.HttpContext context = ((Microsoft.AspNetCore.Http.HttpContextAccessor)factory).HttpContext;
                return context;
            }
        }
    }
}
