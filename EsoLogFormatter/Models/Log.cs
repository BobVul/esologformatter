using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EsoLogFormatter.Models
{
    class Log
    {


        public Log() { }

        public Log(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
        }
    }
}
