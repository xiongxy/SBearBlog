using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;

namespace SBear.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IBlogArticleService _blogArticleService;
        public ArticleController(IBlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
        }
        [Route("Article/{id}")]
        public IActionResult Index(long id)
        { 
            var vv = _blogArticleService.GetArticle(id);
            ViewBag.Article = vv;
            return View();
        }
    }
}
