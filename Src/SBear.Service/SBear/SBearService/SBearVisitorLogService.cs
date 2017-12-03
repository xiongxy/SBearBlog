using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
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

        public SBearVisitorLogDto Insert(string ip)
        {
            var sBearVisitorLog = new SBearVisitorLogEntity()
            {
                IP = ip
            };
            return Mapper.Map<SBearVisitorLogDto>(_repository.Insert(sBearVisitorLog));
        }
    }
}
