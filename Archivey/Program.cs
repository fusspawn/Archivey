using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivey
{
    class Program
    {
        public static ArchiveyServer ServerInstance;
        static void Main(string[] args)
        {
            ServerInstance = new ArchiveyServer();
            ServerInstance.Init();
            Console.WriteLine("Server Running, Type 'exit' to close");

            while (Console.ReadLine() != "exit") {
                Console.WriteLine("Invalid Command: 'exit' to quit");
            }
        }
    }
}
