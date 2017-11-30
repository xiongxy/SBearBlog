using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SBear.Repository.Blog.BlogRepository;
using SBear.Repository.Blog.IBlogRepository;
using SBear.Service.Blog.BlogService;
using SBear.Service.Blog.IBlogService;

namespace SBear.Framework.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogUserRepository>().As<IBlogUserRepository>();
            builder.RegisterType<BlogUserService>().As<IBlogUserService>();

            builder.RegisterType<BlogArticleRepositroy>().As<IBlogArticleRepositroy>();
            builder.RegisterType<BlogArticleService>().As<IBlogArticleService>();
        }
    }
}
