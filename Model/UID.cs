using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UID : BaseModel
    {

        public string? Uid { get; set; }
        public Guid? UserId { get; set; }   
        public User? User { get; set; }
    }
}
