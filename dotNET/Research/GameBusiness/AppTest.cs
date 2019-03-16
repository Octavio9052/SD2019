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
        static string sourceFileName = @"Animal.dll";
        static string sourceDirectory = @"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug\Stage";
        static string destinationDirectory = @"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug";

        // Use Path class to manipulate file and directory paths.
        static string sourceFilePath = Path.Combine(sourceDirectory, sourceFileName);
        static string destinationFilePath = Path.Combine(destinationDirectory, sourceFileName);

        public static void Main(string[] args)
        {
            bool active = true;

            while (active)
            {
                Console.WriteLine("BUSINESS TEST");
                Console.WriteLine("Type anything to copy file");
                Console.ReadLine();
                File.Copy(sourceFilePath, destinationFilePath, true);
                ExecuteDynamicAssembly();

                Console.WriteLine("Type anything to delete file");
                Console.ReadLine();
                while (!File.Exists(destinationFilePath) | IsFileLocked(new FileInfo(destinationFilePath)))
                {
                }

                File.Delete(destinationFilePath);

                Console.WriteLine("Type x to exit");
                if (Console.ReadLine().Equals("x")) active = false;
            }
        }

        private static void ExecuteDynamicAssembly()
        {
            while (!File.Exists(destinationFilePath) | IsFileLocked(new FileInfo(destinationFilePath)))
            {
            }

            AppDomain appDomain = null;
            try
            {
                AppDomainSetup domaininfo = new AppDomainSetup();
                domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
                Evidence adevidence = AppDomain.CurrentDomain.Evidence;
                appDomain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

                var type = typeof(Loader);
                var value = (Loader) appDomain.CreateInstanceAndUnwrap(
                    type.Assembly.FullName,
                    type.FullName);

                var assembly = value.GetAssembly(destinationFilePath);
                var t = assembly.GetType("Animal.Dog");
                var playMethod = t.GetMethod("Play");
                var eatMethod = t.GetMethod("Eat");
                var sleepMethod = t.GetMethod("Sleep");
                var o = Activator.CreateInstance(t);
                BaseAnimalBusiness test;
                test = (BaseAnimalBusiness) o;
                Console.WriteLine(test.Play());
                Console.WriteLine(test.Play());
                Console.WriteLine(test.Play());
                Console.WriteLine(playMethod.Invoke(o, null));
                Console.WriteLine(eatMethod.Invoke(o, null));
                Console.WriteLine(playMethod.Invoke(o, null));
                Console.WriteLine(playMethod.Invoke(o, null));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                AppDomain.Unload(appDomain);
            }
        }


        protected static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }

    public class Loader : MarshalByRefObject
    {
        public Assembly GetAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFile(assemblyPath);
            }
            catch (Exception)
            {
                return null;
                // throw new InvalidOperationException(ex);
            }
        }
    }
}
