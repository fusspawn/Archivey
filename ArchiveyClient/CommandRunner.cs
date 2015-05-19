using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveyClient
{
    public class CommandRunner
    {
        public static bool PreCommand() {
            Config C = Config.Get();
            if (!String.IsNullOrEmpty(C.pre_command)) {
                Console.WriteLine("Found Pre Upload Command.. Running");
                string Shell = Environment.OSVersion.Platform
                    == PlatformID.Unix ? "/bin/bash" : "CMD.exe";

                Process P = new Process();
                P.StartInfo.FileName = Shell;
                P.StartInfo.Arguments = Shell == "CMD.exe" ? $"/C {C.pre_command}" : C.pre_command;
                P.Start();
                P.WaitForExit();                
                Console.WriteLine($"Pre command finished with exitcode: {P.ExitCode}");
                return P.ExitCode == 0; //Good apps return 0 on exit
            }
            else {
                return true;
            }
        }
        public static bool PostCommand() {
            Config C = Config.Get();
            if (!String.IsNullOrEmpty(C.post_command)) {
                Console.WriteLine("Found Post Upload Command.. Running");
                string Shell = Environment.OSVersion.Platform
                    == PlatformID.Unix ? "/bin/bash" : "CMD.exe";
                Process P = new Process();
                P.StartInfo.FileName = Shell;
                P.StartInfo.Arguments = Shell == "CMD.exe" ? $"/C {C.post_command}" : C.post_command;
                P.Start();
                P.WaitForExit();
                Console.WriteLine($"Pre command finished with exitcode: {P.ExitCode}");
                return P.ExitCode == 0; //Good apps return 0 on exit
            }
            else
            {
                return true;
            }
        }
    }
}
