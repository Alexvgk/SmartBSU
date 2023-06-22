using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DayTime : BaseModel
    {
        public string? Day { get; set; }
        public List<Schedule>? Schedules { get; set;}

    }
}
