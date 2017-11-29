using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Entity.Entities
{
    public class SBearArticleEntity : BaseEntity
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public String Label { get; set; }
    }
}
