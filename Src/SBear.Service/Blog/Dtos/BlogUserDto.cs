using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Service.Blog.Dtos
{
    public class BlogUserDto
    {
        public String Nickname { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String GitHubAddress { get; set; }
    }
}
