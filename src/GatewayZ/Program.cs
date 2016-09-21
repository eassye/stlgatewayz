using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayZ
{
    public class Program
    {
        public static void Main(string [] args)
        {
            var host = new WebHostBuilder().UseIISIntegration().UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseStartup<Startup>().Build();

            host.Run();
        }
    }
}
