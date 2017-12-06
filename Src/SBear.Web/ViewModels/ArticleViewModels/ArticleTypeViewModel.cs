using SBear.Service.Blog.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SBear.Web.ViewModels.ArticleViewModels
{
    public class ArticleTypeViewModel
    {
        public List<BlogArticleTypeDto> BlogArticleTypes { get; set; }
    }
}
