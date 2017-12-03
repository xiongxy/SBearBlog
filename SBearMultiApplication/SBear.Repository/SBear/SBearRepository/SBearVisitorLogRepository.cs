using System;
using System.Collections.Generic;
using System.Text;
using SBear.Entities;
using SBear.Entities.SBearEntities;
using SBear.Repository.SBear.ISBearRepository;

namespace SBear.Repository.SBear.SBearRepository

{
    public class SBearVisitorLogRepository : BaseRepository<SBearVisitorLogEntity>, ISBearVisitorLogRepository
    {
        public SBearVisitorLogRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
