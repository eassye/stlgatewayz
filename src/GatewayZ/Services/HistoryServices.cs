using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayZ.Services
{
    public class HistoryServices
    {
        public HistoryServices()
        {

        }

        public int countFiles()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\github\GatewayZ\src\GatewayZ\wwwroot\Images");
            int count = dir.GetFiles().Length;

            return count;
        }
    }
}
