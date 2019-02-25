using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class StudentNumberWriterToFile
    {
        private const string DefaultFilePath = @"D:\Code\SD19\dotNET\HW0103.Threads\HW0103.Threads\res\StudentNumbers.txt";

        public bool WriteToFile(string[] contentStrings)
        {
            return WriteToFile(DefaultFilePath, contentStrings);
        }

        public bool WriteToFile(string path, string[] contentStrings)
        {
            try
            {
                File.WriteAllLines(path, contentStrings, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
                return false;
            }
        }
    }
}
