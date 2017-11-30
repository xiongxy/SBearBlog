using Microsoft.EntityFrameworkCore;
using SBear.Entities.SBearEntities;

namespace SBear.Entities
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
      
    }
}