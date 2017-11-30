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
    public class BlogUserService : IBlogUserService
    {
        private readonly IBlogUserRepository _repository;
        public BlogUserService(IBlogUserRepository repository)
        {
            _repository = repository;
        }
        public BlogUserDto CheckUser(string userName, string password)
        {
            return Mapper.Map<BlogUserDto>(_repository.FirstOrDefault(x =>
                x.UserName == userName && x.Password == password));
        }
        public BlogUserDto GetUser(string userName)
        {
            return Mapper.Map<BlogUserDto>(_repository.FirstOrDefault(x => x.UserName == userName));
        }

        public BlogUserDto Insert(string userName, string password)
        {
            var userEntity = new BlogUserEntity()
            {
                Nickname = userName,
                UserName = userName,
                Password = password,
            };
            return Mapper.Map<BlogUserDto>(_repository.Insert(userEntity));
        }
    }
}
