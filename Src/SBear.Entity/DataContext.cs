using Microsoft.EntityFrameworkCore;
using SBear.Entities.SBearEntities;

namespace SBear.Entities
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SBear.db");
        }
    }
}