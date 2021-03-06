﻿using System;
using System.Collections.Generic;
using System.Text;
using SBear.Service.SBear.Dtos;

namespace SBear.Service.SBear.ISBearService
{
    public interface ISBearVisitorLogService
    {
        bool Insert(string IP);
        int GetTotalVisitorCount();
        IList<SBearVisitorLogDto> GetVisitorLogs();
    }
}
