using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

using Archivey;

namespace Archivey.Controllers
{
    public class DownloadController 
        : NancyModule
    {
        public DownloadController()
            : base("api/download")
        {
            Post["/{api}/{version}"] = _ =>
            {
                return "Downloading";
            };
        }
    }
}
