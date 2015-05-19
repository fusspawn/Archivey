using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveyClient
{
    public class Config
    {
        public string api_url = "http://localhost:8080/api/";
        public string api_key = "00aabe80-d303-4888-827d-1bc694bf01e2";
        public string pre_command = "";
        public string post_command = "";
        public string backupdir = "./";
        public string tempdir = "./tmp";
        public bool UseMultipart = true;

        [JsonIgnore]
        public string UploadUrl {
            get { return api_url + api_key + "/"; }
        }

        public static Config Get() {
            if (File.Exists("config.json")) {
                var ConfigInstance = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                return ConfigInstance;
            }
            else {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(new Config()));
                return Get();
            }
        }
    }
}
