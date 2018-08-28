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
using System.Runtime.Serialization.Formatters.Binary;
namespace SOS
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        //Manager 
        private void button1_Click(object sender, EventArgs e)
        {
            manager_sign_in f = new manager_sign_in();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        //Customer
        private void button2_Click(object sender, EventArgs e)
        {
            sign_in f = new sign_in();
            this.Hide();
            f.ShowDialog();         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }     
    }
}
