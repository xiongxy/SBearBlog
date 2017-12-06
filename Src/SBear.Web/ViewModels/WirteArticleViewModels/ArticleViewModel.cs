using SBear.Service.Blog.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SBear.Web.ViewModels.WirteArticleViewModels
{
    public class ArticleViewModel
    {
        public ArticleActionEnum ArticleAction { get; set; }
        public BlogArticleDto BlogArticle { get; set; }
        public List<SelectListItem> BlogArticleTypes { get; set; }
    }
    public enum ArticleActionEnum
    {
        Add = 1,
        Edit = 2
    }
}
