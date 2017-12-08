using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace SBear.Framework.Config
{
    class SBearConfig
    {
        public BlogAppSettingConfig BlogAppSettingConfig => SBearHttpContext.Current.RequestServices.GetService(typeof(IOptions<BlogAppSettingConfig>)) as BlogAppSettingConfig;
    }
}
