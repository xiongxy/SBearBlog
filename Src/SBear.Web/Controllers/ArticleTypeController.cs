using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;

namespace SBear.Web.Controllers
{
    public class ArticleTypeController : Controller
    {
        private readonly IBlogArticleTypeService _blogArticleType;
        public ArticleTypeController(IBlogArticleTypeService blogArticleType)
        {
            _blogArticleType = blogArticleType;
        }
        [Route("ArticleType/Create/{articleTypeName}")]
        public IActionResult Create(string articleTypeName)
        {
            var blogArticleTypeDto = new BlogArticleTypeDto()
            {
                TypeName = articleTypeName
            };
            _blogArticleType.Insert(blogArticleTypeDto);
            return Content("Create Success");
        }
        [Route("ArticleType/Delete/{articleTypeName}")]
        public IActionResult Delete(string articleTypeName)
        {
            _blogArticleType.Delete(articleTypeName);
            return Content("Delete Success");
        }
    }
}
