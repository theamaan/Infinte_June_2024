using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Windows Task");
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Count Of Characters";
            int z = CountCharacters();
            label1.Text = "Processing the file count... please wait";
            label1.Text = z.ToString() + " " + "Characters Found in the File";

        }
        private int CountCharacters()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("")
           {
            string content =reader.ReadToEnd();
            count = content.Length;
            Thread.Sleep(5000);
           }
           return count;
        }

    private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
