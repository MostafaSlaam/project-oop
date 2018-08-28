using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SOS
{
    class check_product:checker
    {
        public override bool check(string x)
        {
            bool v = false;
            Dictionary<string, products> list = new Dictionary<string, products>();
            if (File.Exists("products.txt"))
            {
                FileStream fst = new FileStream("products.txt", FileMode.Open);
                BinaryFormatter f = new BinaryFormatter();
                while (fst.Position < fst.Length)
                {
                 products   c = (products)f.Deserialize(fst);
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
        }
    }

