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
    public partial class menu : Form
    {
        public menu(string n,string e_m)
        {
            InitializeComponent();
           
            label1.Text="wellcome :";
            label2.Text = sign_in.t1;
        }

        //View Catalog
        private void button1_Click(object sender, EventArgs e)
        {
            x.Visible = true;
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
            x.DataSource = list;
        }

        //Make Order
        private void Order_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible= true;
            button2.Visible = true;
        }

        //Make Order btn
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[0].Cells[0].Value == null || dataGridView1.Rows[0].Cells[1].Value == null)
                {
                    MessageBox.Show("error !!");
                }
                else
                {
                    dliveryboy boy = new dliveryboy();

                    products p = new products();
                    List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
                    float total = 0;
                    DateTime t = DateTime.Now;
                    bool flag = false;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (p.check(dataGridView1.Rows[i].Cells[0].Value.ToString()) && int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) <= p.check_quantity(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (boy.assgin() == null)
                    {
                        MessageBox.Show("Please wait few minutes to make order");
                    }
                    else
                    {
                        bool ff = true;

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            if (int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) <= 0)
                            {
                                MessageBox.Show("falid quantity in row " + ++i);
                                ff = false;
                            }
                        }

                        if (ff)
                        {
                            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                            {
                                if (flag)
                                {
                                    p.buy(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString()));
                                    total += p.return_price_order(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString()));
                                    list.Add(new KeyValuePair<string, int>(dataGridView1.Rows[j].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString())));
                                    MessageBox.Show("done & total= " + total);
                                }
                                else
                                {
                                    MessageBox.Show("invalid name or quantity !!");
                                }
                            }
                            if (flag)
                            {
                                total += 5;
                                orders order = new orders(sign_in.t1, t, list, total, boy.assgin());
                                order.bill(order);
                            }
                        }
                    }
                }
                }
            
            catch
            {
                MessageBox.Show("invalid enter");

            }
        }

        //My Bills
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("bills.txt"))
            {
                FileStream fs = new FileStream("bills.txt",FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                List<orders> list = new List<orders>();
                List<string> l = new List<string>();
                while(fs.Position<fs.Length)
                {
                    orders o = (orders)f.Deserialize(fs);
                    if(o.e_mail==sign_in.t1)
                    {
                        list.Add(o);
                    }
                }
                DataTable p_table= new DataTable();
                p_table.Columns.Add("Bill ID");
                p_table.Columns.Add("Prouduct Name");
                p_table.Columns.Add("Quantity");
                
                DataRow pp;
                for (int ss = 0; ss < list.Count; ss++)
                {
                    for (int cc = 0; cc < list[ss].products.Count; cc++)
                    {
                        pp = p_table.NewRow();

                        pp["Bill ID"] = list[ss].id;
                        pp["Prouduct Name"] = list[ss].products.ElementAt(cc).Key;
                        pp["Quantity"] = list[ss].products.ElementAt(cc).Value;
                        p_table.Rows.Add(pp);
                    }
                }
                dataGridView3.DataSource = p_table;
                fs.Close();
                dataGridView2.DataSource = list;
            }
        }

        //Return Bill
        private void button4_Click(object sender, EventArgs e)
        {
            orders o = new orders();
            if (textBox1.Text.Length == 0||textBox2.Text.Length == 0|| textBox3.Text.Length == 0)
            {
                MessageBox.Show("each failed mandatory");
            }
            else
            {
                string m = o.return_product(int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text));
                MessageBox.Show(m);
                
            }
        }

        //Bill ID digit
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Quantity digit
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Exit
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //back
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            sign_in f = new sign_in();
            f.Show();
        }

        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}