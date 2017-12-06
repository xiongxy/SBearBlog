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
    public class BlogArticleReplyService : IBlogArticleReplyService
    {
        private readonly IBlogArticleReplyRepositroy _repository;
        public BlogArticleReplyService(IBlogArticleReplyRepositroy repository)
        {
            _repository = repository;
        }
    }
}
