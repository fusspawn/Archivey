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

                int RequestVersion = (from upload in _Context.Uploads
                               where upload.ServerId == ClaimedServer.Id
                               select upload).Count() + 1;

                Upload Log = new Upload();
                Log.ServerId = ClaimedServer.Id;
                Log.IsComplete = false;
                Log.UploadedAt = DateTime.UtcNow;
                Log.Hash = "Uploading..";
                Log.Success = false; 
                _Context.Uploads.InsertOnSubmit(Log);
                _Context.SubmitChanges();

                try
                {
                        var file = this.Request.Files.First();

                        SetupPaths(ClaimedServer.Id, RequestVersion);
                        if (File.Exists($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{RequestVersion}/{file.Name}"))
                        {
                            Console.WriteLine("Would Overwrite. Bail");
                            Log.IsComplete = true;
                            Log.Success = false;
                            Log.UploadedAt = DateTime.UtcNow;
                            _Context.SubmitChanges();
                            return "0";
                        }
                        Console.WriteLine($"Handling Fileupload: {file.Name} from server {APIKey}");
                        using (var fStream = new FileStream($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{RequestVersion}/{file.Name}", FileMode.CreateNew))
                        {
                            file.Value.CopyTo(fStream);
                            Console.WriteLine($"Written fileupload to store: {file.Name} from server {APIKey} at version {RequestVersion}");
                        }
                        string Hash = GetMD5($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{RequestVersion}/{file.Name}");
                        if (Hash != _.md5)
                        {
                            Console.WriteLine($"MD5 Missmatch. Got: {Hash} Expected: {_.md5}");
                            Console.WriteLine("Removing Missmatched File");
                            File.Delete($"{Config.ArchiveRootPath}{ClaimedServer.Id}/{RequestVersion}/{file.Name}");
                            Console.WriteLine("Done");

                            Log.IsComplete = true;
                            Log.Success = false;
                            Log.UploadedAt = DateTime.UtcNow;
                            _Context.SubmitChanges();
                            return "0";
                        }
                        else {
                            Console.WriteLine($"MD5 Match. Got: {Hash} Expected: {_.md5}");
                            Console.WriteLine("Confirming Upload");
                            Log.IsComplete = true;
                            Log.Success = true;
                            Log.UploadedAt = DateTime.UtcNow;
                            Log.Hash = Hash;
                            _Context.SubmitChanges();
                            Console.WriteLine("Upload Confirmed");
                            return "1";
                        }
                }
                catch (Exception E) {
                    Console.WriteLine("Upload failed because: " + E.Message.ToString());
                    Log.IsComplete = true;
                    Log.Success = false;
                    Log.UploadedAt = DateTime.UtcNow;
                    _Context.SubmitChanges();
                    return "0";
                }
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
