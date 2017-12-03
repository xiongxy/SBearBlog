using System;
using System.Collections.Generic;
using System.Text;
using SBear.Service.SBear.Dtos;

namespace SBear.Service.SBear.ISBearService
{
    public interface ISBearVisitorLogService
    {
        SBearVisitorLogDto Insert(string IP);
        int GetTotalVisitorCount();
    }
}
