using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CourseGroup : BaseModel
    {
        public string? Course { get; set;}
        public string? Group { get; set;}
        public List<Schedule>? schedules { get; set;}
        public List<User>? users { get; set; }
    }
}
