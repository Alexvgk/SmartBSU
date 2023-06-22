using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserRole : BaseModel
    {
        public string? Role { get; set;}
        public  List<User>? users { get; set;}
    }
}
