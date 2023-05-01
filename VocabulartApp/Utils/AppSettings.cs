using Newtonsoft.Json;
using System;
using System.IO;

namespace SmartBSU.Utils
{
    public class AppSettings
    {
        public string MyDbConnection { get; set; }

        public static AppSettings LoadConfig()
        {
            string configFile = "config.json";
            string configPath = Path.Combine(Environment.CurrentDirectory, configFile);

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Config file not found: {configPath}");
            }

            string json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}
