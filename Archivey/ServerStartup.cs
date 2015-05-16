using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting;
using Nancy.Hosting.Self;

namespace Archivey
{
    public class ArchiveyServer 
    {
        public NancyHost Host;

        public ArchiveyServer() {
            Host = new NancyHost(new Uri("http://localhost:8080"));
        }

        public void Init() {
            Host.Start();
        }
    }
}
