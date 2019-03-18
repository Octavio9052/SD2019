using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace GameBusiness
{
    public class AppTest
    {

        public static void Main(string[] args)
        {
            bool active = true;

            while (active)
            {
                Console.WriteLine("BUSINESS TEST");
                Console.WriteLine("Type anything to copy file");
                Console.ReadLine();
                var test = new Business();
                test.ExecuteDynamicAssembly();

                test = null;

                Console.WriteLine("before cleanning");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.Collect();
                Console.WriteLine("after cleanning");

                Console.WriteLine("Type anything to delete file");
                Console.ReadLine();
                File.SetAttributes(@"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug\Animal.dll", FileAttributes.Normal);
                File.Delete(@"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug\Animal.dll");

                Console.WriteLine("Type x to exit");
                if (Console.ReadLine().Equals("x")) active = false;
            }
        }

        

        
    }
}
