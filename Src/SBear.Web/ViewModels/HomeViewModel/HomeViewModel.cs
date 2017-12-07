using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBear.Service.Blog.Dtos;
using SBear.Web.ViewComponents.Home;

namespace SBear.Web.ViewModels.HomeViewModel
{
    public class HomeViewModel
    {
        public List<BlogArticleDto> BlogArticles { get; set; }
        public CardAciotnTypeEnum CardAciotnType { get; set; }
        public HomeSideBarViewModel HomeSideBarViewModel { get; set; }
        public CardViewModel CardViewModel { get; set; }
    }
}
