using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog.IBlogService
{
    public interface IBlogArticleTypeService
    {
        bool Insert(BlogArticleTypeDto entity);
        List<BlogArticleTypeDto> GetAllList();
        bool Delete(long id);
        BlogArticleTypeDto Get(long id);
    }
}
