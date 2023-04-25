using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Models;
using SmartBSU.Services.DataStore;

namespace SmartBSU.Services.Loader
{
    public interface ILoader
    {
        void ReadStore(IDataStore<Person> dataStore);
        void ReadItem();
    }
}
