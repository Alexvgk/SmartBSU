using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using SmartBSU.Services.DataStore;
using System.Linq;

namespace SmartBSU.Services.Loader
{
    public class LoaderSchedule : ILoader
    {
        private IEnumerable<Model.Schedule> schedules;

        public IEnumerable<Model.Schedule> Schedules
        {
            get { return schedules; }
        }

        public void LoadSchedule()
        {
            DBDataStore<Schedule> dBData = new DBDataStore<Schedule>();
            var response = dBData.GetItemsAsync("/api/Schedule");
            if(response.Result != null)
            {
                schedules = response.Result.Where(c =>c.CGId == AppShell.User.IdCourseGroup);
            }
        }
    }
}
