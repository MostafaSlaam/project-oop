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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
        }

        //Add product
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[0].Cells[0].Value == null || dataGridView1.Rows[0].Cells[1].Value == null || dataGridView1.Rows[0].Cells[2].Value == null)
                {
                    MessageBox.Show("Each field mandatory!");
                }
                else
                {
                    context con = new context(new check_product());
                    if (con.my_function(dataGridView1.Rows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("This product stored !");
                    }

                    else
                    {
                        products p = new products(dataGridView1.Rows[0].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString()), int.Parse(dataGridView1.Rows[0].Cells[2].Value.ToString()));

                        FileStream fs = new FileStream("products.txt", FileMode.Append);
                        BinaryFormatter f = new BinaryFormatter();
                        f.Serialize(fs, p);
                        fs.Close();
                        MessageBox.Show("added");
                        dataGridView1.Rows.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("invalid enter!!!");
            }
        }

        //Delete Product
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows[0].Cells[0].Value == null)
                {
                    MessageBox.Show("Enter Product Name !");
                }
                else
                {
                    context con = new context(new check_product());
                    if (con.my_function(dataGridView2.Rows[0].Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("This product not stored !");
                    }
                    else
                    {
                        //products p = new products();
                        FileStream fs = new FileStream("products.txt", FileMode.Open);
                        BinaryFormatter formatt = new BinaryFormatter();
                        Dictionary<string, products> old = new Dictionary<string, products>();

                        while (fs.Position < fs.Length)
                        {
                            products p = (products)formatt.Deserialize(fs);
                            old[p.name] = p;
                        }
                        fs.Close();
                        old.Remove(dataGridView2.Rows[0].Cells[0].Value.ToString());
                        FileStream fille = new FileStream("products.txt", FileMode.Truncate);
                        fille.Close();
                        FileStream file = new FileStream("products.txt", FileMode.Append);

                        for (int i = 0; i < old.Count; i++)
                        {
                            formatt.Serialize(file, old.ElementAt(i).Value);
                        }
                        old.Clear();
                        file.Close();
                        MessageBox.Show("deleted");
                        dataGridView2.Rows.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("invalid enter");
            }
        }
       
        

        //Check Quantity
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView3.Rows[0].Cells[0].Value == null)
                {
                    MessageBox.Show("Enter Product Name !");
                }
                else
                {
                    context con = new context(new check_product());
                    if (con.my_function(dataGridView3.Rows[0].Cells[0].Value.ToString()) == false)
                    {
                        MessageBox.Show("This product not stored !");
                    }
                    else
                    {
                        FileStream fs = new FileStream("products.txt", FileMode.Open);
                        BinaryFormatter formatt = new BinaryFormatter();

                        while (fs.Position < fs.Length)
                        {
                            products p = (products)formatt.Deserialize(fs);
                            if (p.name == dataGridView3.Rows[0].Cells[0].Value.ToString())
                            {
                                MessageBox.Show("Quantity = " + p.quantity);
                            }
                        }
                        fs.Close();
                        dataGridView3.Rows.Clear();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("invalid enter !!");
            }
        }

        //Add employee 
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView4.Rows[0].Cells[0].Value == null || dataGridView4.Rows[0].Cells[1].Value == null || dataGridView4.Rows[0].Cells[2].Value == null || dataGridView4.Rows[0].Cells[3].Value == null || dataGridView4.Rows[0].Cells[4].Value == null || dataGridView4.Rows[0].Cells[5].Value == null || dataGridView4.Rows[0].Cells[6].Value == null || dataGridView4.Rows[0].Cells[7].Value == null)
                {
                    MessageBox.Show("Each field mandatory!");
                }
                else
                {
                    if (dataGridView4.Rows[0].Cells[0].Value.ToString() == "delivery boy")
                    {
                        context con = new context(new check_boy());
                        if (con.my_function(dataGridView4.Rows[0].Cells[1].Value.ToString()))
                        {
                            MessageBox.Show("This employee is exisit !");
                        }
                        else
                        {
                            dliveryboy d = new dliveryboy();


                            d.add(dataGridView4.Rows[0].Cells[2].Value.ToString(), int.Parse(dataGridView4.Rows[0].Cells[6].Value.ToString()), dataGridView4.Rows[0].Cells[4].Value.ToString(), dataGridView4.Rows[0].Cells[5].Value.ToString(), dataGridView4.Rows[0].Cells[1].Value.ToString(), double.Parse(dataGridView4.Rows[0].Cells[7].Value.ToString()), dataGridView4.Rows[0].Cells[3].Value.ToString());
                            MessageBox.Show("added");
                            dataGridView4.Rows.Clear();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("invalid enter !!");
            }
        }

        //Delete employee
        private void Delete_Emp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Delete_Emp.Rows[0].Cells[0].Value == null || Delete_Emp.Rows[0].Cells[1].Value == null)
                {
                    MessageBox.Show("Enter employee data !");
                }
                else
                {
                    if (Delete_Emp.Rows[0].Cells[0].Value.ToString() == "delivery boy")
                    {
                        context con = new context(new check_boy());
                        if (con.my_function(Delete_Emp.Rows[0].Cells[1].Value.ToString()) == false)
                        {
                            MessageBox.Show("This employee not found !");
                        }
                        else
                        {
                            dliveryboy p = new dliveryboy();
                            FileStream fs = new FileStream("dliveryboy.txt", FileMode.Open);
                            BinaryFormatter formatt = new BinaryFormatter();
                            Dictionary<string, dliveryboy> old = new Dictionary<string, dliveryboy>();

                            while (fs.Position < fs.Length)
                            {
                                p = (dliveryboy)formatt.Deserialize(fs);
                                old[p.id] = p;
                            }

                            fs.Close();
                            old.Remove(Delete_Emp.Rows[0].Cells[1].Value.ToString());
                            FileStream fille = new FileStream("dliveryboy.txt", FileMode.Truncate);
                            fille.Close();
                            FileStream file = new FileStream("dliveryboy.txt", FileMode.Append);

                            for (int i = 0; i < old.Count; i++)
                            {
                                formatt.Serialize(file, old.ElementAt(i).Value);
                            }
                            old.Clear();
                            file.Close();

                            MessageBox.Show("deleted");
                            Delete_Emp.Rows.Clear();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("invalid enter !!");
            }
        }

        //Bills
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("bills.txt"))
            {
                FileStream fs = new FileStream("bills.txt",FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                List<orders> list = new List<orders>();
                while(fs.Position<fs.Length)
                {
                    orders o = (orders)f.Deserialize(fs);
                    list.Add(o);
                }
                fs.Close();
                dataGridView5.DataSource = list;
            }
        }

        //View Bills
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("bills.txt") && textBox1.Text.Length!=0)
            {
                FileStream fs = new FileStream("bills.txt", FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                List<orders> list = new List<orders>();
                while (fs.Position < fs.Length)
                {
                    orders o = (orders)f.Deserialize(fs);
                    if(o.e_mail==textBox1.Text)
                    {
                    list.Add(o);
                    }
                }
                fs.Close();
                dataGridView6.DataSource = list;
            }
        }

        //Update product
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length==0||textBox3.Text.Length==0||comboBox1.Text.Length==0)
            {
                MessageBox.Show("invalid enter !");
            }
            else
            {
                products p=new products();
                context c = new context(new check_product());
                if(c.my_function(textBox2.Text) && int.Parse(textBox3.Text)!=0)
                {
                    if (comboBox1.Text == "NOT CHANGE")
                    {
                        p.update_product(textBox2.Text, int.Parse(textBox3.Text), 0);
                        MessageBox.Show("Done");
                    }
                    else
                    {
                        p.update_product(textBox2.Text, int.Parse(textBox3.Text), int.Parse(comboBox1.Text));
                        MessageBox.Show("Done");
                    }
                }
                else
                { } 
            }
        }

        //View Catalog
        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fss = new FileStream("products.txt", FileMode.Open);
            BinaryFormatter ff = new BinaryFormatter();
            List<products> list = new List<products>();
            list.Clear();
            while (fss.Position < fss.Length)
            {
                products p = (products)ff.Deserialize(fss);
                list.Add(p);
            }
            fss.Close();
            dataGridView7.DataSource = list;
        }

        //Quantity digit
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch)&&ch!=8)
            {
                e.Handled = true;
            }
        }

        //Exit
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Back
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager_sign_in f = new manager_sign_in();
            f.Show();
        }

        //Reset
        private void button7_Click(object sender, EventArgs e)
        {
            if(File.Exists("customer.txt"))
            {
                FileStream fs = new FileStream("customer.txt",FileMode.Truncate);
                fs.Close();
            }
            if (File.Exists("bills.txt"))
            {
                FileStream fs = new FileStream("bills.txt", FileMode.Truncate);
                fs.Close();
            }
            if (File.Exists("dliveryboy.txt"))
            {
                FileStream fs = new FileStream("dliveryboy.txt", FileMode.Truncate);
                fs.Close();
            }
            MessageBox.Show(" Done ");
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
 