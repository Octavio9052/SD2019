using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubcontrollerB
{
    public partial class ListenerView : Form
    {
        private static string data = String.Empty;

        public ListenerView()
        {
            InitializeComponent();
            OpenSocket();
        }

        private void OpenSocket()
        {
            data = SocketListener.StartListening();

            if (txtDisplay.InvokeRequired)
            {
                txtDisplay.Invoke(new Action(SetDisplayText));
            }
        }

        private void SetDisplayText()
        {
            lock (data)
            {
                txtDisplay.Text = data;
            }
        }
    }
}
