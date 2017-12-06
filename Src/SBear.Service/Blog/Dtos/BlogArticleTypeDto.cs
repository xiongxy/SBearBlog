using System;
using System.Collections.Generic;
using System.Text;
namespace SBear.Service.Blog.Dtos
{
    public class BlogArticleTypeDto
    {
        public long Id { get; set; }
        public String TypeName { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateDate => DateTime.Now;
    }
}
