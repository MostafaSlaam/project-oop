using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SOS
{
    
    [Serializable]
    class orders
    {
        public static int i=0;
        public  int id { set;get; }
        public string e_mail { set; get; }
        public DateTime date{ set; get; }
        public List< KeyValuePair<string, int>> products;
        public float total { set; get; }
        public string d_name { set; get; }
        public orders()
        { }
        public orders(string e_mail, DateTime date, List<KeyValuePair<string, int>> products, float total, string d_name)
        {
            orders o=new orders();
            i = o.return_id();
            id = i;
            this.e_mail = e_mail;
            this.date = date;
            this.products = products;
            this.total = total;
            this.d_name = d_name;
        }
        public void bill(orders obj)
        {
            FileStream fs = new FileStream("bills.txt",FileMode.Append);
            BinaryFormatter f = new BinaryFormatter();
            
            f.Serialize(fs,obj);
            fs.Close();
        }
        public int return_id()
        {
            if(File.Exists("bills.txt"))
            {
                
                List<orders> list = new List<orders>();
                FileStream fs = new FileStream("bills.txt", FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                while(fs.Position<fs.Length)
                {
                    orders o = (orders)f.Deserialize(fs);
                    list.Add(o);
                }
                fs.Close();
                return list.Count ;
            }
            else 
                return 0;
        }


        public string return_product(int bill_id,string product, int quantity)
        {
            string return_message;
            if (File.Exists("bills.txt"))
            {
               
                FileStream fs = new FileStream("bills.txt", FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                Dictionary<int, orders> list = new Dictionary<int, orders>();
                KeyValuePair<string, int> li = new KeyValuePair<string, int>();
                // bool falg = false;
                DateTime n = DateTime.Now;
                while (fs.Position < fs.Length)
                {
                    orders o = (orders)f.Deserialize(fs);
                    list[o.id] = o;
                }
                fs.Close();
                if (list.ContainsKey(bill_id))
                {
                    if (list[bill_id].date.Day - n.Day <= 14)
                    {
                        for (int i = 0; i < list[bill_id].products.Count; i++)
                        {
                            if (list[bill_id].products.ElementAt(i).Key == product)
                            {
                                if (list[bill_id].products.ElementAt(i).Value >= quantity&&quantity!=0)
                                {
                                    if (list[bill_id].products.ElementAt(i).Value == quantity)
                                    {
                                        li = new KeyValuePair<string, int>(product, quantity);
                                        list[bill_id].products.Remove(li);
                                        products p = new products();
                                        list[bill_id].total -= p.return_price(product) * quantity;
                                        if(list[bill_id].products.Count==0)
                                        {
                                            list.Remove(bill_id);
                                        }
                                        FileStream format = new FileStream("bills.txt", FileMode.Truncate);
                                        format.Close();
                                        FileStream file = new FileStream("bills.txt", FileMode.Append);
                                        for (int j = 0; j < list.Count; j++)
                                        {
                                            f.Serialize(file, list.ElementAt(j).Value);
                                        }
                                        file.Close();
                                        list.Clear();
                                       
                                        p.update_product(product,quantity,0);
                                        return_message = "done";
                                        list.Clear();
                                        return return_message;
                                    }
                                    else
                                    {
                                        int x = 0;
                                        x = list[bill_id].products.ElementAt(i).Value - quantity;
                                        li = new KeyValuePair<string, int>(product, list[bill_id].products.ElementAt(i).Value);
                                        list[bill_id].products.Remove(li);
                                       
                                        li = new KeyValuePair<string, int>(product,x);
                                        list[bill_id].products.Add(li);
                                        products p = new products();
                                        list[bill_id].total -= p.return_price(product) * quantity;
                                        if (list[bill_id].products.Count == 0)
                                        {
                                            list.Remove(bill_id);
                                        }
                                        FileStream format = new FileStream("bills.txt", FileMode.Truncate);
                                        format.Close();
                                        FileStream file = new FileStream("bills.txt", FileMode.Append);
                                        for (int j = 0; j < list.Count; j++)
                                        {
                                            f.Serialize(file, list.ElementAt(j).Value);
                                        }
                                        file.Close();
                                        list.Clear();
                                        return_message = "done";
                                       p.update_product(product, quantity, 0);
                                       list.Clear();
                                        return return_message;
                                      
                                    }
                                }
                                else
                                {
                                    return_message = "invalid quantity";
                                    return return_message;
                                }
                            }
                            
                        }
                        return_message = "product not found";
                        return return_message;
                    }
                    else
                    {
                        return_message = "over 14 day";
                        return return_message;
                    }
                }
                else
                {
                    return_message = "invalid bill";
                    return return_message;
                }
            }
            else
            {
                return_message = "invalid bill";
                return return_message;
            }
        }

    }

}


