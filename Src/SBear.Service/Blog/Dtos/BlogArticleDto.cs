using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Service.Blog.Dtos
{
    public class BlogArticleDto
    {
        public String Title { get; set; }
        public String Content { get; set; }
        public String Label { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateDate => DateTime.Now;
    }
}
