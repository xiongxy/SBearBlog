using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Framework.Config
{
    public class BlogAppSettingConfig
    {
        public bool IsBuildMdFile { get; set; }
        public string BlogName { get; set; }
        public string BlogImg { get; set; }
        public string BlogPersonalitySignature { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoAuthor { get; set; }
    }
}
