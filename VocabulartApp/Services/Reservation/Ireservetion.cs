using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Models;
using SmartBSU.Services.DataStore;

namespace SmartBSU.Services.Reservation
{
    public interface Ireservetion
    {
        void WriteData(IDataStore<User> dataStore);
        void WriteItem(User item);
    }
}
