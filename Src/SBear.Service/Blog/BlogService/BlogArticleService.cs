using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;
using SBear.Service.Blog.IBlogService;
using SBear.Repository.Blog.IBlogRepository;
namespace SBear.Service.Blog.BlogService
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly IBlogArticleRepositroy _repository;
        public BlogArticleService(IBlogArticleRepositroy repository)
        {
            _repository = repository;
        }
        public BlogArticleDto Insert(BlogArticleDto entity)
        {
            var v = Mapper.Map<BlogArticleEntity>(entity);
            return Mapper.Map<BlogArticleDto>(_repository.Insert(v));
        }

        public BlogArticleDto GetArticle(Guid id)
        {
            return Mapper.Map<BlogArticleDto>(_repository.Get(id));
        }
        public List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => true, x => x.CreateDate));
        }
        public int GetArticleTotalCount(string typeId)
        {
            return Mapper.Map<int>(_repository.GetTotalCount(null));
        }
        public BlogArticleDto GetArticle(long id)
        {
            return Mapper.Map<BlogArticleDto>(_repository.FirstOrDefault(x => x.IdentityId == id));
        }
    }
}
