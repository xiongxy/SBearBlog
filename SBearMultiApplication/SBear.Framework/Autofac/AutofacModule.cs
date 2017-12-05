using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SBear.Entities;
using SBear.Repository.Blog.BlogRepository;
using SBear.Repository.Blog.IBlogRepository;
using SBear.Service.Blog.BlogService;
using SBear.Service.Blog.IBlogService;
using SBear.Repository.SBear.ISBearRepository;
using SBear.Repository.SBear.SBearRepository;
using SBear.Service.SBear.ISBearService;
using SBear.Service.SBear.SBearService;

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

            builder.RegisterType<SBearVisitorLogService>().As<ISBearVisitorLogService>();
            builder.RegisterType<SBearVisitorLogRepository>().As<ISBearVisitorLogRepository>();

            builder.RegisterType<BlogArticleTypeService>().As<IBlogArticleTypeService>();
            builder.RegisterType<BlogArticleTypeRepositroy>().As<IBlogArticleTypeRepositroy>();

        }
    }
}
