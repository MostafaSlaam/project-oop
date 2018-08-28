using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace SOS
{
    class check_boy:checker
    {
        public override bool check(string x)
        {
            bool v = false;

            Dictionary<string, dliveryboy> list = new Dictionary<string, dliveryboy>();
            if (File.Exists("dliveryboy.txt"))
            {
                FileStream fst = new FileStream("dliveryboy.txt", FileMode.Open);

                BinaryFormatter f = new BinaryFormatter();

                dliveryboy c = new dliveryboy();

                while (fst.Position < fst.Length)
                {
                    c = (dliveryboy)f.Deserialize(fst);
                    list[c.id] = c;
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
