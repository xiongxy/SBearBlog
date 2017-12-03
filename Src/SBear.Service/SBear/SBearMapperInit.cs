using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SBear.Entities.SBearEntities;
using SBear.Service.SBear.Dtos;

namespace SBear.Service.SBear
{
    public class SBearMapperInit
    {
        public static void  Init(IMapperConfigurationExpression config)
        {
            config.CreateMap<SBearVisitorLogEntity, SBearVisitorLogDto>();
            config.CreateMap<SBearVisitorLogDto, SBearVisitorLogEntity>();
        }
    }
}
