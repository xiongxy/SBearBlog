﻿using System;
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
    public class CategoryController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        private readonly IBlogArticleService _blogArticleService;
        private readonly IBlogArticleTypeService _blogArticleTypeService;
        private readonly ISBearVisitorLogService _sBearVisitorLogService;
        public CategoryController(IBlogUserService blogUserService, IBlogArticleService blogArticleService, ISBearVisitorLogService sBearVisitorLogService, IBlogArticleTypeService blogArticleTypeService)
        {
            _blogArticleService = blogArticleService;
            _blogUserService = blogUserService;
            _sBearVisitorLogService = sBearVisitorLogService;
            _blogArticleTypeService = blogArticleTypeService;
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
            HomeSideBarViewModel homeSideBarViewModel = new HomeSideBarViewModel();
            homeSideBarViewModel.VisitorLogCount = _sBearVisitorLogService.GetTotalVisitorCount();
            homeSideBarViewModel.HotArticle = _blogArticleService.GetArticleListPageByViewOrderBy(10, 0);
            var vv = _blogArticleService.GetAritcleTypeAndCount();
            var homeSideBarViewModelArticleTypes = vv.GroupBy(x => x.BlogArticleTypeId).Select(g => new HomeSideBarViewModelArticleType
            {
                BlogArticleType = _blogArticleTypeService.Get(g.Key),
                Count = g.Count()
            });
            homeSideBarViewModel.ArticleType = homeSideBarViewModelArticleTypes.ToList();
            return homeSideBarViewModel;
        }
    }
}
