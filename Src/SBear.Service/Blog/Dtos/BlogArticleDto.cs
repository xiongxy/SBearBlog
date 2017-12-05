using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Service.Blog.Dtos
{
    public class BlogArticleDto
    {
        public String Title { get; set; }
        public String MarkDownContent { get; set; }
        public String HtmlContent { get; set; }
        public String Label { get; set; }
        public long IdentityId { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Guid BlogArticleTypeId { get; set; }
    }
}
