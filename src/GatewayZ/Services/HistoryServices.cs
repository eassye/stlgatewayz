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

        public int countFiles(string filePath)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(filePath);
            int count = dir.GetFiles().Length;

            return count;
        }
    }
}
