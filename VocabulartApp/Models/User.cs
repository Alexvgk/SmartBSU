using Android.Service.Autofill;
using System;
using System.Collections.Generic;

namespace SmartBSU.Models
{
    [Serializable]
    public class User : IEquatable<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set;}
        public string Uid { get; set;}
        public int IdRegCode { get; set;}
        public RegCode RegCode { get; set;}

        public override bool Equals(object obj)
        { 
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   FirstName == other.FirstName &&
                   SecondName == other.SecondName &&
                   Email == other.Email &&
                   Uid == other.Uid;
        }

        public override int GetHashCode()
        {
            int hashCode = 741780372;
            hashCode = hashCode * -1521134295 + EqualityComparer<long>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SecondName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Uid);
            return hashCode;
        }
    }

    public class RegCode
    {
        public int IdRegistCode { get; set; }
        public string RegistCode { get; set; }

        public User User { get; set; }
    }
}