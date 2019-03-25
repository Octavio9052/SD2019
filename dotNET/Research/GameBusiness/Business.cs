﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace GameBusiness
{
    class Business
    {

        string sourceFileName = @"Animal.dll";
        string sourceDirectory = @"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug\Stage";
        string destinationDirectory = @"D:\Code\SD19\dotNET\Research\GameBusiness\bin\Debug";

        private Loader _loader;

        public void ExecuteDynamicAssembly()
        {
            //AnimalWrapper testWrapper = new AnimalWrapper();
            string sourceFilePath = Path.Combine(sourceDirectory, sourceFileName);
            string destinationFilePath = Path.Combine(destinationDirectory, sourceFileName);

            if(File.Exists(destinationFilePath)) File.SetAttributes(destinationFilePath, FileAttributes.Normal);
            File.Copy(sourceFilePath, destinationFilePath, true);

            AppDomain appDomain = null;
            try
            {
                appDomain = AppDomain.CreateDomain("ProxyDomain");
                
                _loader = (Loader)appDomain.CreateInstanceAndUnwrap(
                    typeof(Loader).Assembly.FullName,
                    typeof(Loader).FullName);
                LoadAssembly(FileToByteArray(destinationFilePath));
                _loader.Execute();
                Console.WriteLine();
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

        protected byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                FileMode.Open,
                FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            fs.Close();
            br.Close();
            return buff;
        }

        private AppDomain CreateAppDomain()
        {
            Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);

            AppDomain newDomainName = AppDomain.CreateDomain("New Domain", evidence,
                new AppDomainSetup()
                {
                    ApplicationName = "Loader",
                    ApplicationBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    DynamicBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                    LoaderOptimization = LoaderOptimization.MultiDomainHost,
                    PrivateBinPath = GetPrivateBin(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
                });

            this._loader = (Loader)newDomainName.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, typeof(Loader).FullName);
            return newDomainName;
        }

        private string GetPrivateBin(string applicationBase)
        {
            var res = "file:///" + Path.GetFullPath(Path.Combine(applicationBase, @"..\"));
            //var res ="../";
            return res;
        }

        private void LoadAssembly(byte[] stream)
        {
            try
            {
                this._loader.GetAssembly(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
