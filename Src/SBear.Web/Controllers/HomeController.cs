using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;
using SBear.Service.SBear.ISBearService;
using SBear.Web.ViewModels.HomeViewModel;

namespace SBear.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        private readonly ISBearVisitorLogService _iSBearVisitorLogService;
        public HomeController(IBlogUserService blogUserService, IBlogArticleService blogArticleService, ISBearVisitorLogService iSBearVisitorLogService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
            _iSBearVisitorLogService = iSBearVisitorLogService;
        }
        public IActionResult Index(int pageNum)
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                BlogArticles = _blogArticleService.GetArticleListPage(10, pageNum).Select(x =>
                    new BlogArticleDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreateBy = x.CreateBy,
                        HtmlContent = x.HtmlContent.Replace("h1", "h6").Replace("h2", "h6").Replace("h3", "h6").Replace("h4", "h6").Replace("h5", "h6"),
                        Label = x.Label
                    }).ToList(),
                CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeIndex,
                HomeSideBarViewModel = BuildHomeSideBarViewModel(),
                CardViewModel = new ViewModels.CardViewModel()
                {
                    CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeIndex
                }
            };
            return View(homeViewModel);
        }
        public HomeSideBarViewModel BuildHomeSideBarViewModel()
        {
            HomeSideBarViewModel homeSideBarViewModel = new HomeSideBarViewModel();
            homeSideBarViewModel.VisitorLogCount = _iSBearVisitorLogService.GetTotalVisitorCount();
            homeSideBarViewModel.HotArticle = _blogArticleService.GetArticleListPageByViewOrderBy(10, 0);
            var vv = _blogArticleService.GetAritcleTypeAndCount();
            var homeSideBarViewModelArticleTypes = vv.GroupBy(x => x.BlogArticleType).Select(g => new HomeSideBarViewModelArticleType
            {
                BlogArticleType = g.Key,
                Count = g.Count()
            });
            homeSideBarViewModel.ArticleType = homeSideBarViewModelArticleTypes.ToList();
            return homeSideBarViewModel;
        }
    }
}
