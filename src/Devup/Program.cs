using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

namespace Devup
{
    class Program
    {
        static void Main(string[] args)
        {
            DevupMain.Run();


            Console.WriteLine("Hello World!");
        }
    }
    
    public class DevupMain
    {
        public static void Run ()
        {
            DevupConfig.Factory().Run();
        }
    }

    public class DevupConfig : Dictionary<string, Project>
    {
        public void Run()
        {
            this.Values.ToList().ForEach(x => x.Run());
        }

        public static DevupConfig Factory ()
        {
            return new DeserializerBuilder()
                .WithNamingConvention(YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention.Instance)
                .Build().Deserialize<DevupConfig>(File.ReadAllText(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".devup.yml")));
        }
    }

    public class Project
    {
        public string Pwd { get; set; }
        public string Cmd { get; set; }

        public void Run ()
        {
            var p = Process.Start(new ProcessStartInfo()
            {
                WorkingDirectory = Pwd,
                FileName = "PowerShell",
                Arguments = $"-NoLogo -Mta -NoExit {Cmd}",
                CreateNoWindow = false,
                UseShellExecute = true
            });
        }
    }
   
}
