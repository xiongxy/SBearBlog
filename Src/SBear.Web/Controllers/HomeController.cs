using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SBear.Framework;
using SBear.Framework.Config;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;
using SBear.Service.SBear.ISBearService;
using SBear.Web.ViewModels;
using SBear.Web.ViewModels.HomeViewModel;

namespace SBear.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        private readonly IBlogArticleTypeService _blogArticleTypeService;
        private readonly ISBearVisitorLogService _iSBearVisitorLogService;
        private readonly IMemoryCache _cache;

        public HomeController(IBlogUserService blogUserService, IBlogArticleService blogArticleService, ISBearVisitorLogService iSBearVisitorLogService, IBlogArticleTypeService blogArticleTypeService, IMemoryCache memoryCache)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
            _iSBearVisitorLogService = iSBearVisitorLogService;
            _blogArticleTypeService = blogArticleTypeService;
            _cache = memoryCache;
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
                        TextConetent = x.TextConetent.Substring(0, 150),
                        Label = x.Label,
                        CreateBy = x.CreateBy,
                        CreateDate = x.CreateDate,
                    }).ToList(),
                CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeIndex,
                HomeSideBarViewModel = BuildHomeSideBarViewModel(),
                CardViewModel = new CardViewModel()
                {
                    CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeIndex
                }
            };
            return View(homeViewModel);
        }
        [Route("Search/{key?}")]
        public IActionResult Searcher(string key)
        {
            var data = _blogArticleService.GetArticleListByKey(key, 10, 0).Select(x =>
                new BlogArticleDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    TextConetent = x.TextConetent.Substring(0, 150),
                    Label = x.Label,
                    CreateBy = x.CreateBy,
                    CreateDate = x.CreateDate,
                }).ToList();
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                BlogArticles = data,
                CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeSearch,
                HomeSideBarViewModel = BuildHomeSideBarViewModel(),
                CardViewModel = new CardViewModel()
                {
                    SearchCount = data.Count,
                    CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeSearch
                }
            };
            return View("Index", homeViewModel);
        }
        [Route("Category/{id?}")]
        public IActionResult Category(long id)
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                BlogArticles = _blogArticleService.GetArticleListByCatgory(id, 10, 0).Select(x =>
                    new BlogArticleDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        TextConetent = x.TextConetent.Substring(0, 150),
                        Label = x.Label,
                        CreateBy = x.CreateBy,
                        CreateDate = x.CreateDate,
                    }).ToList(),
                CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeCatgory,
                HomeSideBarViewModel = BuildHomeSideBarViewModel(),
                CardViewModel = new CardViewModel()
                {
                    CardAciotnType = ViewComponents.Home.CardAciotnTypeEnum.HomeCatgory,
                    Catgory = _blogArticleTypeService.Get(id)
                }
            };
            return View("Index", homeViewModel);
        }
        public HomeSideBarViewModel BuildHomeSideBarViewModel()
        {
            if (!_cache.TryGetValue("cache_HomeSideBar", out HomeSideBarViewModel homeSideBar))
            {
                HomeSideBarViewModel homeSideBarViewModel = new HomeSideBarViewModel();
                homeSideBarViewModel.VisitorLogCount = _iSBearVisitorLogService.GetTotalVisitorCount();
                homeSideBarViewModel.HotArticle = _blogArticleService.GetArticleListPageByViewOrderBy(10, 0);
                var vv = _blogArticleService.GetAritcleTypeAndCount();
                var homeSideBarViewModelArticleTypes = vv.GroupBy(x => x.BlogArticleTypeId).Select(g => new HomeSideBarViewModelArticleType
                {
                    BlogArticleType = _blogArticleTypeService.Get(g.Key),
                    Count = g.Count()
                });
                homeSideBarViewModel.ArticleType = homeSideBarViewModelArticleTypes.ToList();
                _cache.Set("cache_HomeSideBar", homeSideBarViewModel);
                homeSideBar = homeSideBarViewModel;
            }
            return homeSideBar;
        }
    }
}
