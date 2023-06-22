using System;
using System.Collections.Generic;
using System.Text;
using Model;
using SmartBSU.Services.DataStore;

namespace SmartBSU.Services.Loader
{
    public interface ILoader
    {
        void LoadSchedule();
    }
}
