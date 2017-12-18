﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace SBear.Framework.Config
{
    public static class SBearConfig
    {
        public static BlogAppSettingConfig BlogAppSettingConfig => (SBearHttpContext.Current.RequestServices.GetService(typeof(IOptions<BlogAppSettingConfig>)) as IOptions<BlogAppSettingConfig>)?.Value;
    }
}
