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
            Host = new NancyHost(new Uri(Config.Get().BindTo));
        }

        public void Init() {
            StaticConfiguration.DisableErrorTraces = false;
            Host.Start();
        }
    }
}
