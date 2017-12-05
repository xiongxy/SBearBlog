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
    public class BlogArticleTypeService : IBlogArticleTypeService
    {
        private readonly IBlogArticleTypeRepositroy _repository;
        public BlogArticleTypeService(IBlogArticleTypeRepositroy repository)
        {
            _repository = repository;
        }

        public bool Delete(string typeName)
        {
            return _repository.Delete(x => x.TypeName == typeName);
        }

        public List<BlogArticleTypeDto> GetAllList()
        {
            return Mapper.Map<List<BlogArticleTypeDto>>(_repository.GetAllList(x => true));
        }

        public BlogArticleTypeDto Insert(BlogArticleTypeDto entity)
        {
            var v = Mapper.Map<BlogArticleTypeEntity>(entity);
            return Mapper.Map<BlogArticleTypeDto>(_repository.Insert(v));
        }
    }
}
