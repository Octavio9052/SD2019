using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControllerA;

namespace PortsUnmanaged
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string textToSend = string.Empty;

            if (txtSample.Text.Length > 0) textToSend = txtSample.Text;

            SocketSenderClient.StartClient(textToSend);

            /*var senderSocket = SocketSenderClient.ReturnConnectedSocket();
            senderSocket.Send(EncondeText(textToSend));
            SocketSenderClient.ReleaseSocket(senderSocket);*/
        }

        private byte[] EncondeText(string textToSend)
        {
            // Encode the data string into a byte array.  
            byte[] msg = Encoding.ASCII.GetBytes(textToSend + "<EOF>");

            return msg;
        }
    }
}
