using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.VisualBasic.CompilerServices;
using SBear.Entities.SBearEntities;
using SBear.Service.SBear.Dtos;
using SBear.Service.SBear.ISBearService;
using SBear.Repository.SBear.ISBearRepository;

namespace SBear.Service.SBear.SBearService
{
    public class SBearVisitorLogService : ISBearVisitorLogService
    {
        private readonly ISBearVisitorLogRepository _repository;
        public SBearVisitorLogService(ISBearVisitorLogRepository repository)
        {
            _repository = repository;
        }

        public int GetTotalVisitorCount()
        {
            return Mapper.Map<int>(_repository.GetTotalCount(t => true));
        }

        public IList<SBearVisitorLogDto> GetVisitorLogs()
        {
            return Mapper.Map<List<SBearVisitorLogDto>>(_repository.GetAllList(t => true));
        }

        public bool Insert(string ip)
        {
            var sBearVisitorLog = new SBearVisitorLogEntity()
            {
                Ip = ip,
                CreateDate = DateTime.Now
            };
            var record = _repository.FirstOrDefault(x => x.Ip == ip);
            if (record == null || GetTimeDifference(record.CreateDate.Value, DateTime.Now) > 2)
            {
                _repository.Insert(sBearVisitorLog);
                return true;
            }
            return false;
        }
        public int GetTimeDifference(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts1 = new TimeSpan(dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(dt2.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            return ts3.Hours;
        }
    }
}
