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
   public  class products
    {



       public string name { set; get; }
       public float price { set; get; }
       public int quantity { set; get; }
       public products()
       { }
        public products(string name, float price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public bool check(string x)
        {
            bool v = false;

            Dictionary<string, products> list = new Dictionary<string, products>();
            if (File.Exists("products.txt"))
            {
                FileStream fst = new FileStream("products.txt", FileMode.Open);

                BinaryFormatter f = new BinaryFormatter();

                products c = new products();

                while (fst.Position < fst.Length)
                {
                    c = (products)f.Deserialize(fst);
                    list[c.name] = c;
                }

                fst.Close();

                if (list.ContainsKey(x))
                {
                    v = true;
                }


                list.Clear();

            }
            else
            {
                v = false;

            }

            return v;

        }

       public void update_product(string n,int q,int p)
       {
            context c=new context(new check_product());
            if (c.my_function(n))
           {
               FileStream fs = new FileStream("products.txt",FileMode.Open);
               BinaryFormatter f = new BinaryFormatter();
                Dictionary<string,products> list =new Dictionary<string,products>();
                while(fs.Position<fs.Length)
                {
                    products pr = (products)f.Deserialize(fs);
                    list[pr.name] = pr;
                }
                fs.Close();
                if (p == 0)
                {
                    list[n].quantity += q;
                }
                else
                {
                    list[n].price = p;
                    list[n].quantity += q;
                }
              
                FileStream formatt = new FileStream("products.txt",FileMode.Truncate);
                formatt.Close();
                FileStream file = new FileStream("products.txt",FileMode.Append);
                for (int i = 0; i < list.Count;i++ )
                {
                    f.Serialize(file,list.ElementAt(i).Value);
                }
                file.Close();
           }
       }

        public float return_price(string product)
        {
            context c=new context(new check_product());
            float y = 0;
            if(c.my_function(product))
            {
                FileStream fs = new FileStream("products.txt",FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                while(fs.Position<fs.Length)
                {
                    products p = (products)f.Deserialize(fs);
                    if(p.name==product)
                    {
                        y= p.price;
                    }
                }
                fs.Close();
                return y;
            }
            else 
                return y;
        }


        public int check_quantity(string x)
        {
           
              if(File.Exists("products.txt"))
               {
                   FileStream fs = new FileStream("products.txt",FileMode.Open);
                   BinaryFormatter f = new BinaryFormatter();
                  while(fs.Position<fs.Length)
                  {
                      products p = (products)f.Deserialize(fs);
                      if(p.name==x)
                      {
                          fs.Close();
                          return p.quantity;
                      }
                  }
                  fs.Close();
                    return -1;
              }
              else
              {
                  return -1;
              }
        }

        public void buy(string n,int q)
        {
            FileStream fs = new FileStream("products.txt", FileMode.Open);            
            BinaryFormatter f = new BinaryFormatter();
            Dictionary<string, products> list = new Dictionary<string, products>();
            products p = new products();
            while(fs.Position<fs.Length)
            {
                p = (products)f.Deserialize(fs);
                if(p.name==n)
                {
                    p.quantity -= q;
                    list[p.name] = p;
                }
                list[p.name] = p;
            }
            fs.Close();
            FileStream formatt = new FileStream("products.txt", FileMode.Truncate);
            formatt.Close();
            FileStream file = new FileStream("products.txt",FileMode.Append);
            for (int i = 0; i < list.Count;i++ )
            {
                f.Serialize(file,list.ElementAt(i).Value);
            }
            file.Close();
        }

        public float return_price_order(string n, int q)
        {

            FileStream fs = new FileStream("products.txt", FileMode.Open);
            BinaryFormatter f = new BinaryFormatter();
            products p = new products();
            while (fs.Position < fs.Length)
            {
                p = (products)f.Deserialize(fs);
                if (p.name == n)
                {
                    fs.Close();
                    return p.price * q;

                }
            }
            fs.Close();
            return -1;
        }
    }
}
