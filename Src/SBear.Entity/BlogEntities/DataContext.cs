using Microsoft.EntityFrameworkCore;
using SBear.Entities.BlogEntities;

namespace SBear.Entities
{
    public partial class DataContext
    {
        public DbSet<BlogUserEntity> BlogUser { get; set; }
        public DbSet<BlogArticleEntity> BlogArticle { get; set; }
        public DbSet<BlogArticleTypeEntity> BlogArticleType { get; set; }
        public DbSet<BlogArticleReplyEntity> BlogArticleReply { get; set; }

    }
}
