using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;

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
            var vv = _blogArticleService.GetArticleListPage(10, pageNum).Select(x =>
                new BlogArticleDto
                {
                    IdentityId = x.IdentityId,
                    Title = x.Title,
                    CreateBy = x.CreateBy,
                    HtmlContent = x.HtmlContent.Replace("h1", "h6").Replace("h2", "h6").Replace("h3", "h6").Replace("h4", "h6").Replace("h5", "h6"),
                    Label = x.Label
                }).ToList();

            ViewBag.Articles = vv;
            return View();
        }

    }
}
