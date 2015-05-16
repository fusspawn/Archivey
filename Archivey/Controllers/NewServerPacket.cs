using Archivey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivey.Controllers
{
    public class NewServerPacket
    {
        public string IP;
        public string Name;
    }

    public class ServersDisplayModel {
        public List<Server> Servers;
        public ServersDisplayModel(List<Server> list) {
            Servers = list;
        }
    }
}
