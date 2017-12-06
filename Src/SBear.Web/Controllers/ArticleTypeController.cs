﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;
using SBear.Web.Filters;
using SBear.Web.ViewModels.ArticleViewModels;
namespace SBear.Web.Controllers
{
    [CheckLoginAuthorize]
    public class ArticleTypeController : Controller
    {
        private readonly IBlogArticleTypeService _blogArticleType;
        public ArticleTypeController(IBlogArticleTypeService blogArticleType)
        {
            _blogArticleType = blogArticleType;
        }
        public IActionResult Index()
        {
            ArticleTypeViewModel articleTypeViewModel = new ArticleTypeViewModel();
            articleTypeViewModel.BlogArticleTypes = _blogArticleType.GetAllList();
            return View(articleTypeViewModel);
        }
        public IActionResult Create(string articleTypeName)
        {
            var blogArticleTypeDto = new BlogArticleTypeDto()
            {
                TypeName = articleTypeName
            };
            _blogArticleType.Insert(blogArticleTypeDto);
            return RedirectToAction("Index"); ;
        }
        public IActionResult Delete(long id)
        {
            _blogArticleType.Delete(id);
            return RedirectToAction("Index"); ;
        }
    }
}
