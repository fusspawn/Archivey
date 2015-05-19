using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivey
{
    public class Config
    {
        public string ArchiveRootPath = "E:/ArchiveyTest/";
        public string BindTo = "http://localhost:8080";

        public static Config Get()
        {
            if (File.Exists("config.json"))
            {
                var ConfigInstance = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                return ConfigInstance;
            }
            else
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(new Config()));
                return Get();
            }
        }
    }
}
