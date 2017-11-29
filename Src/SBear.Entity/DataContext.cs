using System;
using Microsoft.EntityFrameworkCore;
using SBear.Entity.Entities;

namespace SBear.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<SBearUserEntity> SBearUserEntitys { get; set; }
        public DbSet<SBearArticleEntity> SBearArticleEntitys { get; set; }
    }
}