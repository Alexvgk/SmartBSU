using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SmartBSU.Models;
using SmartBSU.Services.DataStore;

namespace SmartBSU.Services.Loader
{
    internal class LoaderData : ILoader
    {
        public void ReadItem()
        {
            
        }

        public void ReadStore(IDataStore<Person> dataStore)
        {
            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            //string path = Path.Combine(documentsPath, "piropara.json");
            var path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\" + "pirapare" + @".json";
            dataStore = JsonConvert.DeserializeObject<IDataStore<Person>>(File.ReadAllText(path));
           // if (HistoryNote == null) HistoryNote = new History();
        }
    }
}
