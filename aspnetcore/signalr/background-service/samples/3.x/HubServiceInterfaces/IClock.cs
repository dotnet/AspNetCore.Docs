﻿using System;
using System.Threading.Tasks;

namespace HubServiceInterfaces
{
#region IClock
    public interface IClock
    {
        Task ShowTime(DateTime currentTime);
    }
#endregion
}
