using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SOS
{
    class check_customer:checker
    {
        public override bool check(string x)
        {
            bool v = false;

            Dictionary<string, customer> list = new Dictionary<string, customer>();
            if (File.Exists("customer.txt"))
            {
                FileStream fst = new FileStream("customer.txt", FileMode.Open);

                BinaryFormatter f = new BinaryFormatter();

                customer c = new customer();

                while (fst.Position < fst.Length)
                {
                    c = (customer)f.Deserialize(fst);
                    list[c.e_mail] = c;
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
