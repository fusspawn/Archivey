using Archivey.Models;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;

namespace Archivey.Controllers
{
    public class ServerAPI
        : NancyModule
    {
        public ServerAPI()
            : base("api/server") {
            DBModelDataContext Context = new DBModelDataContext();

            Get["/"] = _ =>  {
                List<Server> Servers = (from server in Context.Servers select server).ToList();
                return View["view.sshtml", new ServersDisplayModel(Servers)];
            };

            Post["/new"] = (_) =>  {
                Server ServerObject = new Server();
                NewServerPacket PostData = this.Bind<NewServerPacket>();
                ServerObject.Name = PostData.Name;
                ServerObject.IP = PostData.IP;
                ServerObject.APIKey = Guid.NewGuid().ToString();
                ServerObject.LastContact = DateTime.UtcNow;
                ServerObject.LastUpload = DateTime.UtcNow;
                ServerObject.UserId = -1;
                Context.Servers.InsertOnSubmit(ServerObject);
                Context.SubmitChanges();
                List<Server> Servers = (from server in Context.Servers select server).ToList();
                return View["view.sshtml", new ServersDisplayModel(Servers)];
            };

            Post["/delete/{id}/{api}"] = (_) =>
            {
                int ID = _.id;
                string API = _.api;

                var ToDelete = (from p in Context.Servers where p.Id == ID 
                                && p.APIKey == API select p).SingleOrDefault();
                if (ToDelete != null) {
                    Context.Servers.DeleteOnSubmit(ToDelete);
                    Context.SubmitChanges();
                }

                List<Server> Servers = (from server in Context.Servers select server).ToList();
                return View["view.sshtml", new ServersDisplayModel(Servers)];
            };

            Post["/revokeapi/{id}/{api}"] = _ =>
            {
                int ID = _.id;
                string API = _.api;

                var Revoke = (from p in Context.Servers
                              where p.Id == ID
                              && p.APIKey == API
                              select p).SingleOrDefault();
                if (Revoke != null)
                {
                    Revoke.APIKey = Guid.NewGuid().ToString();
                    Context.SubmitChanges();
                }

                List<Server> Servers = (from server in Context.Servers select server).ToList();
                return View["view.sshtml", new ServersDisplayModel(Servers)];
            };
        }
    }
}
