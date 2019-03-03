using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*var ProcessData = PrepareProcessData();
            var ServicesData = PrepareServiceData();

            RunApp(ProcessData, ServicesData);*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TaskMain());
        }

        static List<Process> PrepareProcessData()
        {
            return null; //new ProcessRetriever().ProcessesData;
        }

        static List<ServiceController> PrepareServiceData()
        {
            return null; //new ServiceRetriever().ServicesData;
        }

        static void RunApp(List<Process> processes, List<ServiceController> services)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TaskMain());
        }
    }
}
