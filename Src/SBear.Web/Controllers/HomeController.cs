using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels;
using SBear.Web.ViewModels.HomeViewModel;
using SBear.Entities.BlogEntities;

namespace SBear.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        public HomeController(IBlogUserService blogUserService, IBlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
        }
        public IActionResult Index(int pageNum)
        {
            ViewBag.Articles = _blogArticleService.GetArticleListPage(10, pageNum);
            return View();

        }
        public IActionResult WriteArticle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriteArticle(ArticleViewModel vm)
        {
            _blogArticleService.Insert(vm);
            return View();
        }
    }
}
