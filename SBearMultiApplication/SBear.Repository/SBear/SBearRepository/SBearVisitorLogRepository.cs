using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SBear.Entities;
using SBear.Entities.SBearEntities;
using SBear.Repository.SBear.ISBearRepository;

namespace SBear.Repository.SBear.SBearRepository

{
    public class SBearVisitorLogRepository : BaseRepository<SBearVisitorLogEntity>, ISBearVisitorLogRepository
    {
        private readonly DataContext _dataContext;
        public SBearVisitorLogRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public SBearVisitorLogEntity GetListRecord(Expression<Func<SBearVisitorLogEntity,bool>> predicate)
        {
            return _dataContext.Set<SBearVisitorLogEntity>().OrderByDescending(x => x.CreateDate).FirstOrDefault(predicate);
        }
    }
}

