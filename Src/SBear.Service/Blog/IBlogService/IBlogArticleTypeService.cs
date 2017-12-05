using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog.IBlogService
{
    public interface IBlogArticleTypeService
    {
        BlogArticleTypeDto Insert(BlogArticleTypeDto entity);
        List<BlogArticleTypeDto> GetAllList();
        bool Delete(String typeName);
    }
}
