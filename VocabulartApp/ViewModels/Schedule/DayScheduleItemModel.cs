using Java.Net;
using Model;
using SmartBSU.Services.DataStore;
using SmartBSU.Services.Loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SmartBSU.ViewModels.Schedule
{
    public class DayScheduleItemModel : BaseViewModel
    {
        private string titleDay;
        private List<Model.Schedule> schedules;
        public string TitleDay
        {
            get { return titleDay; }
            set
            {
                if (titleDay != value)
                {
                    titleDay = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Model.Schedule> Schedules
        {
            get { return schedules;}
            set
            {
                if (schedules != value)
                {
                    schedules = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool SetSchedule(IEnumerable<Model.Schedule> item)
        {
            if(String.IsNullOrEmpty(titleDay))
                return false;
            DBDataStore<DayTime> dBData = new DBDataStore<DayTime>();
            var response = dBData.GetItemsAsync("/api/DayTime");
            if (response.Result.FirstOrDefault(w => w.Day == titleDay) != null) {
                var dayID = response.Result.FirstOrDefault(w => w.Day == titleDay).Id;
                schedules = item.Where(w => w.DayId == dayID).ToList();
                schedules.Sort((a,b) => String.Compare(a.Time,b.Time));
                return true;
            }
            else { return false; }
        }
    }
}
