using System;
using System.Linq.Expressions;
using SBear.Entities.SBearEntities;

namespace SBear.Repository.SBear.ISBearRepository
{
    public interface ISBearVisitorLogRepository : IRepository<SBearVisitorLogEntity>
    {
        SBearVisitorLogEntity GetListRecord(Expression<Func<SBearVisitorLogEntity, bool>> predicate);
    }
}
