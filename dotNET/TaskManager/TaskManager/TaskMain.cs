﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace TaskManager
{
    public partial class TaskMain : Form
    {
        readonly ManagementEventWatcher _processStartEvent =
            new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");

        readonly ManagementEventWatcher _processStopEvent =
            new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
        
        private ProcessRetriever ProcessRetriever = new ProcessRetriever();
        private ServiceRetriever ServiceRetriever = new ServiceRetriever();
            

        public TaskMain()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(TaskMain_Load);

            _processStartEvent.EventArrived += new EventArrivedEventHandler(ProcessStartEvent_EventArrived);
            _processStartEvent.Start();
            _processStopEvent.EventArrived += new EventArrivedEventHandler(ProcessStopEvent_EventArrived);
            _processStopEvent.Start();
        }

        private void TaskMain_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void LoadListView()
        {
            ProcessRetriever.UpdateProcessData().ProcessListView(mainListView);
            ServiceRetriever.UpdateServicesData().ServicesListView(servicesListView);
        }

        private void mainListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProcessStopEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (mainListView.InvokeRequired)
            {
                mainListView.Invoke(new Action(LoadListView));
            }

            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            Console.WriteLine("Process stopped Name: {0} | ID: {1}", processName, processID);
        }

        private void ProcessStartEvent_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (mainListView.InvokeRequired)
            {
                mainListView.Invoke(new Action(LoadListView));
            }

            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processID = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value).ToString();

            Console.WriteLine("Process started. Name: {0} | ID: {1}", processName, processID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessRetriever.KillProcessById(int.Parse(input_pid.Text));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                input_pid.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessRetriever.StartProcessByName(input_pname.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                input_pname.Text = string.Empty;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            try
            {
                ProcessRetriever.GetMemoryUsedByProcessById(int.Parse(input_pmid.Text), txt_memory);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                input_pmid.Text = string.Empty;
            }
        }
    }
}
