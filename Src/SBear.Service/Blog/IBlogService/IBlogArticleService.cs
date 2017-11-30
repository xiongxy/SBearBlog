using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog.IBlogService
{
    public interface IBlogArticleService
    {
        BlogArticleDto Insert(BlogArticleEntity entity);
        BlogArticleDto GetArticle(Guid id);
        List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum);
        int GetArticleTotalCount(string typeId);
    }
}
