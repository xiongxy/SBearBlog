using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBear.Framework.Util;
using SBear.Service.Blog.IBlogService;
using SBear.Web.Filters;
using SBear.Web.ViewModels.WirteArticleViewModels;
namespace SBear.Web.Controllers
{
    [CheckLoginAuthorize]
    public class WriteArticleController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        private readonly IBlogArticleTypeService _blogArticleTypeService;

        public WriteArticleController(IBlogUserService blogUserService, IBlogArticleService blogArticleService, IBlogArticleTypeService blogArticleTypeService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
            _blogArticleTypeService = blogArticleTypeService;
        }

        [HttpGet("WriteArticle/{id?}")]
        public IActionResult Index(long id)
        {
            var articleAction = ArticleActionEnum.Edit;
            var article = _blogArticleService.GetArticle(id);
            if (article == null)
            {
                articleAction = ArticleActionEnum.Add;
                article = new Service.Blog.Dtos.BlogArticleDto();
            }
            List<SelectListItem> v = new List<SelectListItem>();
            _blogArticleTypeService.GetAllList().ForEach(x =>
            {
                SelectListItem b = new SelectListItem();
                b.Text = x.TypeName;
                b.Value = x.Id.ToString();
                v.Add(b);
            });
            ArticleViewModel articleViewModel = new ArticleViewModel
            {
                BlogArticle = article,
                BlogArticleTypes = v,
                ArticleAction = articleAction
            };
            return View(articleViewModel);
        }
        [HttpPost]
        public IActionResult Index(ArticleViewModel vm)
        {
            switch (vm.ArticleAction)
            {
                case ArticleActionEnum.Add:
                    vm.BlogArticle.Id = Convert.ToInt64(TimestampId.GetInstance().GetId());
                    _blogArticleService.Insert(vm.BlogArticle);
                    break;
                case ArticleActionEnum.Edit:
                    _blogArticleService.Update(vm.BlogArticle);
                    break;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
