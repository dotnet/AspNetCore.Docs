using CachingSample.Abstractions;
using System;

namespace CachingSample.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
