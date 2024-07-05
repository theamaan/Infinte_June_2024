using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using RemoteServerLibrary;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpChannel c = new HttpChannel(8002);
            ChannelServices.RegisterChannel(c);


            //create a service class object (that is the proxy for the remote object)
            RemoteServices rserviceproxy = (RemoteServices)Activator.GetObject(typeof(RemoteServices),
                "http://localhost:86/OurRemoteServices");
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            label3.Text = "The max number is :" + rserviceproxy.WriteMessage(x, y);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
