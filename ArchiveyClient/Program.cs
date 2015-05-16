using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace ArchiveyClient
{
    class Program
    {

        static void Main(string[] args)
        {
            Uploader Upload = new Uploader();
            Upload.Tick();
            Console.ReadLine();
        }
    }
}
