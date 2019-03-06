using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    class ServiceRetriever
    {
        private List<ServiceController> ServicesData { get; set; }

        public ServiceRetriever()
        {
            UpdateServicesData();
        }

        public ServiceRetriever UpdateServicesData()
        {
            var services = new List<ServiceController>();
            foreach (var service in ServiceController.GetServices())
            {
                if ((service.Status == ServiceControllerStatus.Running)|(service.Status == ServiceControllerStatus.StartPending)) services.Add(service);
            }

            this.ServicesData = services;

            return this;
        }

        private ListViewItem ServiceItem(ServiceController service)
        {
            string[] row =
            {
                service.ServiceName,
                service.DisplayName,
                service.StartType.ToString(),
                service.Status.ToString()
            };
            var listViewItem = new ListViewItem(row);
            return listViewItem;
        }

        public void ServicesListView(ListView servicesListView)
        {
            // Reset
            servicesListView.Items.Clear();

            foreach (var service in ServicesData)
            {
                servicesListView.Items.Add(ServiceItem(service));
            }
        }

        public void ServicesListView2(ListView servicesListView)
        {
            string[] row =
            {
                "Test",
                "Test2",
                "Test3",
                "Test4"
            };
            servicesListView.Items.Add(new ListViewItem(row));
            
        }
    }
}
