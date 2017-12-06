using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities;
using SBear.Entities.BlogEntities;
using SBear.Repository.Blog.IBlogRepository;

namespace SBear.Repository.Blog.BlogRepository
{
    public class BlogArticleReplyRepositroy : BaseRepository<BlogArticleReplyEntity>, IBlogArticleReplyRepositroy
    {
        public BlogArticleReplyRepositroy(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
