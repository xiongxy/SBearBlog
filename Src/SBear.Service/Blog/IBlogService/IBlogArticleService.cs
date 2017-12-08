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
        BlogArticleDto GetArticle(long id);
        List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum);
        int GetArticleTotalCount(string typeId);
        void AddArticleView(long id);
        List<BlogArticleDto> GetArticleListPageByViewOrderBy(int pageSize, int pageNum);
        BlogArticleDto Update(BlogArticleDto entity);
        List<BlogArticleDto> GetArticleListByKey(string key, int pageSize, int pageNum);
        List<BlogArticleDto> GetArticleListByCatgory(long id, int pageSize, int pageNum);
        List<BlogArticleDto> GetAritcleTypeAndCount();
        bool Delete(long id);
    }
}
