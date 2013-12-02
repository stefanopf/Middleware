using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace HangmanServer
{
    public partial class ServerForm : Form
    {
        ServiceHost host;
        bool serverIsOn = false;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if(serverIsOn)
                host.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serverIsOn)
            {
                host.Close();
                label1.Text = "Server is Off";
                button1.Text = "Turn on Server";
            }
            else
            {
                host = new ServiceHost(typeof(Server));
                host.Open();
                label1.Text = "Server is On";
                button1.Text = "Turn off Server";
            }
            serverIsOn = !serverIsOn;
        }
    }
}
