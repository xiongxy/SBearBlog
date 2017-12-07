using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;
using SBear.Service.SBear.ISBearService;
using SBear.Web.ViewModels;
using SBear.Web.ViewModels.HomeViewModel;

namespace SBear.Web.Controllers
{
    public class CatgoryController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        private readonly IBlogArticleTypeService _iBlogArticleTypeService;
        private readonly ISBearVisitorLogService _iSBearVisitorLogService;
        public CatgoryController(IBlogUserService blogUserService, IBlogArticleService blogArticleService, ISBearVisitorLogService iSBearVisitorLogService, IBlogArticleTypeService iBlogArticleTypeService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
            _iSBearVisitorLogService = iSBearVisitorLogService;
            _iBlogArticleTypeService = iBlogArticleTypeService;
        }

        public IActionResult Index(long id)
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                BlogArticles = _blogArticleService.GetArticleListByCatgory(id, 10, 0).Select(x =>
                    new BlogArticleDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreateBy = x.CreateBy,
                        HtmlContent = x.HtmlContent.Replace("h1", "h6").Replace("h2", "h6").Replace("h3", "h6")
                            .Replace("h4", "h6").Replace("h5", "h6"),
                        Label = x.Label
                    }).ToList(),
                CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeCatgory,
                HomeSideBarViewModel = BuildHomeSideBarViewModel(),
                CardViewModel = new CardViewModel()
                {
                    CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeCatgory,
                    Catgory = _iBlogArticleTypeService.Get(id)
                }
            };
            return View("../Home/Index", homeViewModel);
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
