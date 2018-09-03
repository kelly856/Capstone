﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utility_Logger
{
    public class Error_Logger
    {
        public void Errorlogger(Exception error)
        {
            //Error message
            string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "----------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("message {0}", error.Message);
            message += Environment.NewLine;
            message += string.Format("Stack Trace {0}", error.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", error.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", error.TargetSite.ToString());
            message += Environment.NewLine;
            message += "----------------------------------------------";
            message += Environment.NewLine;
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Onshore\\Desktop\\CapstoneErrorLogger", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
