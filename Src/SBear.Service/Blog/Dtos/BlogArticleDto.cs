using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Service.Blog.Dtos
{
    public class BlogArticleDto
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public String MarkDownContent { get; set; }
        public String HtmlContent { get; set; }
        public String TextConetent { get; set; }
        public String Label { get; set; }
        public int Views { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public long BlogArticleTypeId { get; set; }
        public BlogArticleTypeDto BlogArticleType { get; set; }

    }
}
