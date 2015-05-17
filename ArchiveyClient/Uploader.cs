using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace ArchiveyClient
{
    class Uploader
    {
        public string APIKey = "00aabe80-d303-4888-827d-1bc694bf01e2";
        public string UploadURL = "http://localhost:8080/api/upload/";
        public WebClient UploadClient = new WebClient();
        public string BackupLocation = "E:\\Games\\GOG Games\\Papers, Please";
        public string TemporaryStorage = "./tmp";

        public Uploader(string TargetDirectory, string TempLocation)
        {
            BackupLocation = TargetDirectory;
            TemporaryStorage = TempLocation;
        }

        public Uploader() {
            UploadURL = Config.Get().api_url;
            APIKey = Config.Get().api_key;
        }

        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        private void CreateFile()
        {
            Console.WriteLine("Creating UploadFile");

            if (!System.IO.Directory.Exists($"{TemporaryStorage}")) {
                System.IO.Directory.CreateDirectory($"{TemporaryStorage}");
            }
            if (!System.IO.Directory.Exists($"{TemporaryStorage}/archive"))
            {
                System.IO.Directory.CreateDirectory($"{TemporaryStorage}/archive");
            }

            CopyFilesRecursively(new DirectoryInfo(BackupLocation), new DirectoryInfo($"{TemporaryStorage}/archive"));
            ZipFile.CreateFromDirectory($"{TemporaryStorage}/archive", 
                $"{TemporaryStorage}/backup.zip", CompressionLevel.Optimal, false);

            Console.WriteLine("Upload file created");
        }

        public bool Upload() {
            Console.WriteLine("Trying to upload to.. " + $"{UploadURL}upload/{APIKey}/examplehash");
            Console.WriteLine("Uploading file.. Make take a while");
            string hash = GetMD5();
            string result = UploadClient.UploadFile($"{UploadURL}upload/{APIKey}/{hash}", $"{TemporaryStorage}/backup.zip").ToString();
            Console.WriteLine($"Uploaded Result was: {result}");
            return result == "1";
        }

        public void CleanUp() {
            if (File.Exists($"{TemporaryStorage}/backup.zip")) {
                Console.WriteLine("tmp file found.. Removing");
                File.Delete($"{TemporaryStorage}/backup.zip");
                Console.WriteLine("Removed");
            }

            if (System.IO.Directory.Exists($"{TemporaryStorage}/archive"))
                System.IO.Directory.Delete($"{TemporaryStorage}/archive", true);

            Console.WriteLine("Cleanup complete");
        }


        public void Tick() {
            try
            {
                CreateFile();
                Upload();
            }
            catch (OutOfMemoryException E)
            {
                Console.WriteLine("Upload Error: " + E.Message.ToString());
            }
            finally {
                CleanUp();
            }
        }

        public string GetMD5() {
            using (var Hash = MD5.Create()) {
                using (var Stream = File.OpenRead($"{TemporaryStorage}/backup.zip")) {
                    return BitConverter.ToString(Hash.ComputeHash(Stream)).Replace("-", "").ToLower();
                }
            }
        }
    }
}
