using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class LessonForm : BaseModel
    { 
        public string? Form { get; set; }
        public List<Schedule> Schedules { get; set;}
    }
}
