using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TaskManager
{
    class ProcessRetriever
    {
        private static List<Process> ProcessesData { get; set; }
        private SortedSet<string> UniqueProcess { get; set; }
        private readonly string DefaultFilePath = @"D:\Octavio\Descargas\test.ico";

        public ProcessRetriever()
        {
            UpdateProcessData();
        }

        public ProcessRetriever UpdateProcessData()
        {
            var processList = new List<Process>();
            var uniqueProcessName = new SortedSet<string>();
            foreach (var process in Process.GetProcesses(Environment.MachineName))
            {
                processList.Add(process);
                uniqueProcessName.Add(process.ProcessName);
            }

            ProcessesData = processList.OrderBy(x => x.ProcessName).ToList();
            UniqueProcess = uniqueProcessName;
            return this;
        }

        private void AttachImageToProcess(ListView main)
        {
            foreach (ListViewItem item in main.Items)
            {
                item.ImageIndex = main.SmallImageList.Images.IndexOfKey(item.SubItems[0].Text);
            }
        }

        private ImageList ProcessesImages()
        {
            ImageList ProcessesImages = new ImageList();

            foreach (var item in ProcessesData)
            {
                try
                {
                    ProcessesImages.Images.Add(
                        item.Id.ToString(),
                        Icon.ExtractAssociatedIcon(item.MainModule.FileName).ToBitmap()
                    );
                }
                catch
                {
                    ProcessesImages.Images.Add(
                        item.Id.ToString(),
                        Icon.ExtractAssociatedIcon(DefaultFilePath).ToBitmap()
                    );
                }
            }


            return ProcessesImages;
        }

        private ListViewGroup CreateProcessGroup(string processName)
        {
            ListViewGroup newGroup = new ListViewGroup(processName);
            return newGroup;
        }

        private ListViewItem ProcessItem(Process process)
        {
            string[] row =
            {
                    process.Id.ToString(),
                    process.ProcessName,
                    string.Empty,
                    (process.Responding)? "Responding" : "Not responding",
                    process.MachineName,
                    string.Empty,
                    ProcessPath(process)
            };

            var listViewIem = new ListViewItem(row, CreateProcessGroup(process.ProcessName));

            return listViewIem;
        }

        public void ProcessListView(ListView mainListView)
        {
            // Copy
            
            Dictionary<string, int> temp = new Dictionary<string, int>();
            // Reset
            mainListView.Groups.Clear();
            mainListView.Items.Clear();

            // Create groups
            int i = 0;
            foreach (var unique in UniqueProcess)
            {
                mainListView.Groups.Add(CreateProcessGroup(unique));
                temp.Add(unique, i++);
            }
            // Add to items (assign groups)
            foreach (var process in ProcessesData)
            {
                var item = ProcessItem(process);
                if (temp.TryGetValue(process.ProcessName, out i)) item.Group = mainListView.Groups[i];
                mainListView.Items.Add(item);
            }

            // Count instances
            foreach (ListViewItem item in mainListView.Items)
            {
                item.SubItems[2].Text = item.Group.Items.Count.ToString();
            }

            // Attach icon
            mainListView.LargeImageList = ProcessesImages();
            mainListView.SmallImageList = mainListView.LargeImageList;
            AttachImageToProcess(mainListView);
        }

        public static string ProcessPath(Process process)
        {
            try
            {
                return process.MainModule.FileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void KillProcessById(int pid)
        {
            Process.GetProcessById(pid).Kill();
        }

        public static void StartProcessByName(string name)
        {
            Process.Start(name);
        }

        public static void GetMemoryUsedByProcessById(int pid, Label memoryLabel)
        {
            var processName = ProcessesData.Find(x => x.Id.Equals(pid)).ProcessName;
            int i = 0;
            foreach (var instanceProcess in ProcessesData.FindAll(x => x.ProcessName.Equals(processName)))
            {
                if ((instanceProcess.Id == pid) & (i>0) )
                    memoryLabel.Text = MemoryUsedByProcess(processName + "#" + i) + " / " + BytesToReadableValue(ProcessesData.Find(x => x.Id.Equals(pid)).PrivateMemorySize64);
                else if (instanceProcess.Id == pid)
                    memoryLabel.Text = MemoryUsedByProcess(processName) + " / " + BytesToReadableValue(ProcessesData.Find(x => x.Id.Equals(pid)).PrivateMemorySize64);
                i++;
            }
        }

        private static string MemoryUsedByProcess(string process)
        {
            try
            {
                double memory = 0;
                PerformanceCounter performanceCounter = new PerformanceCounter();

                performanceCounter.CounterName = "Working Set - Private";
                performanceCounter.CategoryName = "Process";
                performanceCounter.InstanceName = process;

                memory = performanceCounter.NextValue();

                performanceCounter.Close();
                performanceCounter.Dispose();

                return String.Format(" {0:F} MB", (memory / 1024d) / 1024d);
            }
            catch (Win32Exception win32)
            {
                return "Not allowed " + win32.ToString();
            }
            catch (Exception e)
            {
                return "Something went wrong " + e.ToString();
            }
        }

        private static string BytesToReadableValue(double number)
        {
            number = (number/1024d) / 1024d;

            return String.Format(" {0:F} MB", number);
        }
    }
}
