using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SBear.Entities.SBearEntities;

namespace SBear.Entities
{
    public partial class DataContext
    {
        public DbSet<SBearUserEntity> SBearUserEntities { get; set; }
        public DbSet<SBearArticleEntity> SBearArticleEntities { get; set; }
        public DbSet<SBearVisitorLogEntity> SBearVisitorLogEntities { get; set; }
    }
}
