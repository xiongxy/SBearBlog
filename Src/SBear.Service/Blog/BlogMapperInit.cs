using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SBear.Entities.BlogEntities;
using SBear.Service.Blog.Dtos;

namespace SBear.Service.Blog
{
    public class BlogMapperInit
    {
        public static void  Init(IMapperConfigurationExpression config)
        {
            config.CreateMap<BlogUserEntity, BlogUserDto>();
            config.CreateMap<BlogUserDto, BlogUserEntity>();

            config.CreateMap<BlogArticleEntity, BlogArticleDto>();
            config.CreateMap<BlogArticleDto, BlogArticleEntity>();
        }
    }
}
