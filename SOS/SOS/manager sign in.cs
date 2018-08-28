using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOS
{
    public partial class manager_sign_in : Form
    {
        public manager_sign_in()
        {
            InitializeComponent();
        }

        //Submit
        private void button1_Click(object sender, EventArgs e)
        {
            manager m = new manager();
            //intialize
            m.name = "admin";
            m.password = "admin";
            if (textBox1.Text==m.name && textBox2.Text==m.password)
            {
              Form2 f = new Form2();
                this.Hide();
                f.ShowDialog();
              
                textBox2.Clear();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("invalid enter !");
            }
        }

         //Exit
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Back
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            start f = new start();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void manager_sign_in_Load(object sender, EventArgs e)
        {

        }
    }
}
