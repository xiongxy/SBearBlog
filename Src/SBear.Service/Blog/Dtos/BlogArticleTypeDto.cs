using System;
using System.Collections.Generic;
using System.Text;
namespace SBear.Service.Blog.Dtos
{
    public class BlogArticleTypeDto
    {
        public String TypeName { get; set; }
        public long IdentityId { get; set; }
        public String CreateBy { get; set; }
        public DateTime CreateDate => DateTime.Now;
    }
}
