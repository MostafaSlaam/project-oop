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
   //public static customer g = new customer();
    public partial class sign_in : Form
    {
        public static string t1 = "";
       
        public sign_in()
        {
            InitializeComponent();
        }

        //Sign Up
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox3.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || comboBox1.Text.Length == 0 || comboBox2.Text.Length == 0 || comboBox3.Text.Length == 0 || comboBox4.Text.Length == 0)
            {
                MessageBox.Show("Each field is nesseccary !");
            }
            else
            {
                context con = new context(new check_customer());
                customer c = new customer();
                if (con.my_function(textBox3.Text))
                {
                    MessageBox.Show("This email is already exisit !");
                }
                else
                {
                    if(comboBox4.Text=="male"||comboBox4.Text=="female")
                    {
                    DateTime d=new DateTime (int.Parse(comboBox1.Text),int.Parse(comboBox2.Text),int.Parse(comboBox3.Text));
                    DateTime to = DateTime.Today;
                    c.age = to.Year - d.Year;
                    c.name = textBox4.Text;
                    c.e_mail = textBox3.Text;
                    c.password = textBox7.Text;
                    c.sex = comboBox4.Text;
                    c.address = textBox5.Text;
                    c.phone = textBox6.Text;
                    c.add(c);
                    t1 = c.name;
                   
                    MessageBox.Show(" done ");
                    menu f = new menu(c.name,c.e_mail);
                    this.Hide();
                    f.ShowDialog();
                }
                    else
                    {
                        MessageBox.Show("invalid sex!!");
                    }
                }
            }
        }

        //Sign in
        private void button1_Click(object sender, EventArgs e)
        {
            customer c=new customer();
            if (textBox1.Text .Length==0 || textBox2.Text .Length==0)
            {
                MessageBox.Show("Enter email & password !");
            }
            else
            {
                if (c.check_sign_in(textBox1.Text,textBox2.Text))
                {
                    t1 = textBox1.Text;
                    menu f = new menu( c.name, c.e_mail);
                    this.Hide();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This email not found !");
                }
            }
        }

        //Digit Phone 
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Exit
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //back
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            start f = new start();
            f.Show();
        }
      
        //Year Digit
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Month Digit
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Day Digit
        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void sign_in_Load(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
