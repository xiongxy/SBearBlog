using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBear.Service.Blog.Dtos;

namespace SBear.Web.ViewModels.HomeViewModel
{
    public class HomeSideBarViewModel
    {
        public int VisitorLogCount { get; set; }
        public List<BlogArticleDto> HotArticle { get; set; }
    }
}
