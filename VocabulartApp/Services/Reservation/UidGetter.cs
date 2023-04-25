using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBSU.Services.Reservation
{
    public class UidGetter
    {
        private string UID;
        private static UidGetter Instance;


        private UidGetter()
        {
        }
        public static UidGetter getInstanse()
        {
            if(Instance == null)
            {
                Instance = new UidGetter();
            }
            return Instance;
        }

        public string getUID()
        {
            return UID;
        }
        public void SetUID(string uid)
        {
            UID = uid;  
        }
    }
}
