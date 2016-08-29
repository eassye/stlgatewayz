﻿using System;
using System.Collections.Generic;
using System.IO;
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

        public string LastDateModified(string filePath)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(filePath);
                string date = dir.LastWriteTime.ToShortDateString();
                return date;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public string[] FileName(string filePath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(filePath);

                string[] fileArray = Directory.GetFiles(filePath);

                return fileArray;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
