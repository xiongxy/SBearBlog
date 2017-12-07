using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public BlogArticleDto GetArticle(long id)
        {
            return Mapper.Map<BlogArticleDto>(_repository.Get(id));
        }
        public List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => true, x => x.CreateDate));
        }
        public List<BlogArticleDto> GetArticleListPage(int pageSize, int pageNum, Expression<Func<BlogArticleDto, bool>> Order)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => true, x => x.CreateDate));
        }
        public int GetArticleTotalCount(string typeId)
        {
            return _repository.GetTotalCount(null);
        }
        public void AddArticleView(long id)
        {
            var v = _repository.Get(id);
            v.Views += 1;
            _repository.Update(v);
        }
        public List<BlogArticleDto> GetArticleListByKey(string key, int pageSize, int pageNum)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => x.Title.Contains(key) || x.TextConetent.Contains(key), x => x.CreateDate));
        }
        public BlogArticleDto Update(BlogArticleDto entity)
        {
            var v = Mapper.Map<BlogArticleEntity>(entity);
            return Mapper.Map<BlogArticleDto>(_repository.Update(v));
        }
        public List<BlogArticleDto> GetArticleListPageByViewOrderBy(int pageSize, int pageNum)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => true, x => x.Views));
        }

        public List<BlogArticleDto> GetAritcleTypeAndCount()
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.GetAllList(predicate: x => true, include: x => x.BlogArticleType).ToList());
        }

        public List<BlogArticleDto> GetArticleListByCatgory(long id, int pageSize, int pageNum)
        {
            return Mapper.Map<List<BlogArticleDto>>(_repository.LoadPageList(pageNum, pageSize, out int count, x => x.BlogArticleTypeId == id, x => x.CreateDate));
        }
    }
}
