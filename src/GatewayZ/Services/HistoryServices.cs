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

        public int CountFiles(string filePath)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(filePath);
                int count = dir.GetFiles().Length;
                return count;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public DateTime LastDateModified(string filePath)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(filePath);
                DateTime date = dir.LastWriteTime;
                return date;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
