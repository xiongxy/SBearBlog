using System;
using System.Collections.Generic;
using System.Text;

namespace SBear.Framework.Util
{
    public class ConvertUtil
    {
        public string GetTimeDifference(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts1 = new TimeSpan(dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(dt2.Ticks);
            TimeSpan ts3 = ts1.Subtract(ts2).Duration();
            return ts3.Hours.ToString();
        }
    }
}
