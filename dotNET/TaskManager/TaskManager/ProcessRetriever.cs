using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TaskManager
{
    class ProcessRetriever
    {
        private List<Process> ProcessesData { get; set; }
        private SortedSet<string> UniqueProcess { get; set; }
        private readonly string DefaultFilePath = @"D:\Octavio\Descargas\test.ico";

        public ProcessRetriever()
        {
            UpdateProcessData();
        }

        private void UpdateProcessData()
        {
            var processList = new List<Process>();
            var uniqueProcessName = new SortedSet<string>();
            foreach (var process in Process.GetProcesses())
            {
                processList.Add(process);
                uniqueProcessName.Add(process.ProcessName);
            }

            ProcessesData = processList.OrderBy(x => x.ProcessName).ToList();
            UniqueProcess = uniqueProcessName;
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
                    "",
                    (process.Responding)? "Responding" : "Not responding",
                    process.MachineName,
                    ""
                };
            var listViewIem = new ListViewItem(row, CreateProcessGroup(process.ProcessName));
            return listViewIem;
        }

        public void ProcessListView(ListView mainListView)
        {
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

        }
    }
}
