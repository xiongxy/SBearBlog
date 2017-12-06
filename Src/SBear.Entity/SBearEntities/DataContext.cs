using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SBear.Entities.SBearEntities;

namespace SBear.Entities
{
    public partial class DataContext
    {
        public DbSet<SBearUserEntity> SBearUser { get; set; }
        public DbSet<SBearArticleEntity> SBearArticle { get; set; }
        public DbSet<SBearVisitorLogEntity> SBearVisitorLog { get; set; }
    }
}
