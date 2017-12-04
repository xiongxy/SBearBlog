using System;
using Microsoft.AspNetCore.Mvc;
using SBear.Framework.Util;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels.WirteArticleViewModels;
namespace SBear.Web.Controllers
{

    public class WriteArticleController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        public WriteArticleController(IBlogUserService blogUserService, IBlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
        }
        [HttpGet("WriteArticle/{id?}")]
        public IActionResult Index(long id)
        {
            var article = _blogArticleService.GetArticle(id);
            ArticleViewModel articleViewModel = new ArticleViewModel
            {
                Title = article.Title,
                Label = article.Label,
                IdentityId = article.IdentityId,
                HtmlContent = article.HtmlContent,
                MarkDownContent = article.MarkDownContent
            };
            return View(articleViewModel);
        }
        [HttpPost]
        public IActionResult WriteArticle(ArticleViewModel vm)
        {
            vm.IdentityId = Convert.ToInt64(TimestampId.GetInstance().GetID());
            _blogArticleService.Insert(vm);
            return RedirectToAction("Index", "Home");
        }
    }
}
