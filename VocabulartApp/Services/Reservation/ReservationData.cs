using Android.Content.Res;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using SmartBSU.Models;
using SmartBSU.Services.DataStore;
using Xamarin.Forms.PlatformConfiguration;
using static Java.Util.Jar.Attributes;

namespace SmartBSU.Services.Reservation
{
    public class ReservationData : Ireservetion
    {
        public void WriteData(IDataStore<User> dataStore)
        {

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(folderPath, "parapam.json");
            //string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            //string path =  "piropara.json";
          
            File.WriteAllText(path, JsonConvert.SerializeObject(dataStore));
        }

        public void WriteItem(User item )
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            string path = "piropara.json";
            //string path = Path.Combine(documentsPath, "piropara.json");
            using (var writer = File.CreateText(path))
            {
                writer.Write(item); //асинхронно 
            }
           // string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            //string path = Path.Combine(documentsPath, "piropara.json");
            //File.WriteAllText(path, JsonConvert.SerializeObject(item));
        }
    }
}
