using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Nancy;
using Archivey.Models;
using System.IO;
using System.Security.Cryptography;

namespace Archivey.Controllers
{
    public class UploadController 
        : NancyModule
    {
        DBModelDataContext _Context;

        public UploadController()
            : base("api/upload/")

        {
            _Context = new DBModelDataContext();
            Post["/{api}/{md5}"] = _ =>
            {

                string APIKey = _.api;
                Server ClaimedServer = (from p in _Context.Servers where p.APIKey == APIKey select p).SingleOrDefault();

                if (ClaimedServer == null)
                {
                    Console.WriteLine($"ClaimedServer not found for API: {APIKey}");
                    return "0";
                }

                int Version = (from upload in 
                               ClaimedServer.Uploads
                               select upload).Count() + 1;
                try
                {
                    foreach (var file in this.Request.Files)
                    {
                        SetupPaths(ClaimedServer.Id, Version);
                        if (File.Exists($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{ Version}/{file.Name}"))
                        {
                            Console.WriteLine("Would Overwrite. Bail");
                            return "0";
                        }
                        Console.WriteLine($"Handling Fileupload: {file.Name} from server {APIKey}");
                        using (var fStream = new FileStream($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{Version}/{file.Name}", FileMode.CreateNew))
                        {
                            file.Value.CopyTo(fStream);
                            Console.WriteLine($"Written fileupload to store: {file.Name} from server {APIKey} at version {Version}");
                        }
                        string Hash = GetMD5($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{Version}/{file.Name}");
                        if (Hash != _.md5)
                        {
                            Console.WriteLine($"MD5 Missmatch. Got: {Hash} Expected: {_.md5}");
                            Console.WriteLine("Removing Missmatched File");
                            File.Delete($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{Version}/{file.Name}");
                            Console.WriteLine("Done");
                            return "0";
                        }
                        else {
                            Console.WriteLine($"MD5 Match. Got: {Hash} Expected: {_.md5}");
                        }

                    }

                    Upload Log = new Upload();
                    Log.ServerId = ClaimedServer.Id;
                    Log.UploadedAt = DateTime.UtcNow;
                    _Context.Uploads.InsertOnSubmit(Log);
                    _Context.SubmitChanges();
                }
                catch (Exception E) {
                    Console.WriteLine("Upload failed because: " + E.Message.ToString());
                    return "0";
                }

                return "1";
            };
            Get["/"] = _ =>
            {
                return View["view.sshtml", new UploadsDisplayModel((from upload 
                                                                    in _Context.Uploads
                                                                    select upload).ToList())];
            };
        }

        public string GetMD5(string Filepath)
        {
            using (var Hash = MD5.Create())
            {
                using (var Stream = File.OpenRead(Filepath))
                {
                    return BitConverter.ToString(Hash.ComputeHash(Stream)).Replace("-", "").ToLower();
                }
            }
        }

        private void SetupPaths(int id, int version)
        {
            if (!Directory.Exists($"{Config.ArchiveRootPath}{id}/{version}"))
                Directory.CreateDirectory($"{Config.ArchiveRootPath}{id}/{version}");
        }
    }

    public class UploadsDisplayModel
    {
        public List<Upload> Backups;
        public UploadsDisplayModel(List<Upload> list)
        {
            Backups = list;
        }
    }
}
