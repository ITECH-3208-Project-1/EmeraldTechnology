using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Desktop_app
{
    public partial class Form1 : Form
    {






        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customerpage myForm = new Customerpage();
            myForm.Show();
            //this.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Help hel = new Help();
            hel.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Organisation org = new Organisation();
            org.ShowDialog();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

        }

        public static void getData()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }
 
    }
}
