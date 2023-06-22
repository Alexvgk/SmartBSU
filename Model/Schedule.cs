using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Schedule : BaseModel
    {
        public string? Name { get; set;}
        public string? Time { get; set;}
        public string? Lecture { get; set;}
        public string? Classroom { get; set;}
        public Guid? IdForm { get; set;}
        public Guid? CGId { get; set;}
        public Guid? DayId { get;set;}
        public CourseGroup? CorseGroup { get; set;}
        public LessonForm? LessonForm { get; set;}  
        public DayTime? DayTime { get; set;}    
    }
}
