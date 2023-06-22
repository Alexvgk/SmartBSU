using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class RegCode : BaseModel
    {
        public string? RegistCode { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
