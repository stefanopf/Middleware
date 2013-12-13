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
        private ServiceHost host;
        private bool serverIsOn = false;
        private Timer t = new Timer();

        public ServerForm()
        {
            t.Interval = 1000;
            t.Tick += updateScreen;
            this.FormClosing += ServerForm_OnClose;
            InitializeComponent();
        }

        private void ServerForm_OnClose(object sender, FormClosingEventArgs e)
        {
            if (serverIsOn)
                host.Close();
        }

        private void updateScreen(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<List<string>> listOfItems = Server.getOnlinePlayersList();
            List<string> userNames = listOfItems[0];//0 = username
            List<string> totalGuesses = listOfItems[1];//1 = total guesses
            List<string> correctGuesses = listOfItems[2];//2 = correct guesses
            List<string> gameIDs = listOfItems[3];



            for (int i = 0; i < userNames.Count; i++)
            {
                string[] items = new string[3];
                items[0] = userNames[i];
                items[1] = correctGuesses[i] + "\\" + totalGuesses[i];
                items[2] = gameIDs[i];

                ListViewItem lstItem = new ListViewItem(items);
                listView1.Items.Add(lstItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serverIsOn)
            {
                host.Close();
               // labelMessage.Text = ServerInfo.saveDataBase();
                labelStatus.Text = "Server is Off";
                button1.Text = "Turn on Server";
                listView1.Visible = false;
                labelPos2.Visible = false;
                listView1.Invalidate();
                t.Stop();
            }
            else
            {
                host = new ServiceHost(typeof(Server));
                //labelMessage.Text = ServerInfo.LoadDataBase();
                host.Open();
                labelStatus.Text = "Server is On";
                button1.Text = "Turn off Server";
                listView1.Visible = true;
                labelPos2.Visible = true;
                Invalidate();
                t.Start();
            }
            serverIsOn = !serverIsOn;
        }

    }
}
