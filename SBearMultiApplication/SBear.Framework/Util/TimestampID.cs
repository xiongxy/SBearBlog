﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SBear.Framework.Util
{
    public class TimestampId
    {
        /// <summary>
        /// 时间戳ID
        /// </summary>

        private long _lastTimestamp;
        private long _sequence; //计数从零开始
        private readonly DateTime? _initialDateTime;
        private static TimestampId _timestampId;
        private const int MaxEndNumber = 9999;

        private TimestampId(DateTime? initialDateTime)
        {
            _initialDateTime = initialDateTime;
        }

        /// <summary>
        /// 获取单个实例对象
        /// </summary>
        /// <param name="initialDateTime">最初时间，与当前时间做个相差取时间戳</param>
        /// <returns></returns>
        public static TimestampId GetInstance(DateTime? initialDateTime = null)
        {
            if (_timestampId == null)
                Interlocked.CompareExchange(ref _timestampId, new TimestampId(initialDateTime), null);
            return _timestampId;
        }

        /// <summary>
        /// 最初时间，作用时间戳的相差
        /// </summary>
        protected DateTime InitialDateTime
        {
            get
            {
                if (_initialDateTime == null || _initialDateTime.Value == DateTime.MinValue)
                    return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return _initialDateTime.Value;
            }
        }

        /// <summary>
        /// 获取时间戳ID
        /// </summary>
        /// <returns></returns>
        public string GetId()
        {
            var timestamp = GetUniqueTimeStamp(_lastTimestamp, out var temp);
            return $"{timestamp}{Fill(temp)}";
        }

        private string Fill(long temp)
        {
            var num = temp.ToString();
            IList<char> chars = new List<char>();
            for (int i = 0; i < MaxEndNumber.ToString().Length - num.Length; i++)
            {
                chars.Add('0');
            }
            return new string(chars.ToArray()) + num;
        }

        /// <summary>
        /// 获取一个时间戳字符串
        /// </summary>
        /// <returns></returns>
        public long GetUniqueTimeStamp(long lastTimeStamp, out long temp)
        {
            lock (this)
            {
                temp = 1;
                var timeStamp = GetTimestamp();
                if (timeStamp == _lastTimestamp)
                {
                    _sequence = _sequence + 1;
                    temp = _sequence;
                    if (temp >= MaxEndNumber)
                    {
                        timeStamp = GetTimestamp();
                        _lastTimestamp = timeStamp;
                        temp = _sequence = 1;
                    }
                }
                else
                {
                    _sequence = 1;
                    _lastTimestamp = timeStamp;
                }
                return timeStamp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private long GetTimestamp()
        {
            if (InitialDateTime >= DateTime.Now) throw new Exception("最初时间比当前时间还大，不合理");
            var ts = DateTime.UtcNow - InitialDateTime;
            return (long)ts.TotalMilliseconds;
        }
    }
}
