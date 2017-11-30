using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities;
using SBear.Entities.BlogEntities;
using SBear.Repository.Blog.IBlogRepository;

namespace SBear.Repository.Blog.BlogRepository
{
    public class BlogArticleRepositroy : BaseRepository<BlogArticleEntity>, IBlogArticleRepositroy
    {
        public BlogArticleRepositroy(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
