using Microsoft.EntityFrameworkCore;
using SBear.Entities.BlogEntities;

namespace SBear.Entities
{
    public partial class DataContext
    {
        public DbSet<BlogUserEntity> BlogUserEntities { get; set; }
        public DbSet<BlogArticleEntity> BlogArticleEntities { get; set; }
    }
}
