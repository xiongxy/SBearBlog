using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog.IBlogService
{
    public interface IBlogArticleService
    {
        BlogArticleDto Insert(BlogArticleDto entity);
        BlogArticleDto GetArticle(Guid id);
        BlogArticleDto GetArticle(long id);
        List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum);
        int GetArticleTotalCount(string typeId);
    }
}
