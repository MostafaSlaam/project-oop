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
    class customer:person
    {
        public string e_mail;
        public string password;
        public customer()
        { }
        public customer(string name, int age, string address, string phone, string sex,string e_mail,string password)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
            this.sex = sex;
            this.e_mail = e_mail;
            this.password = password;
        }

        public bool check_sign_in(string x,string y)
        {
            bool v = false;
            context con = new context(new check_customer());
            Dictionary<string, customer> list = new Dictionary<string, customer>();
            if (con.my_function(x))
            {
                FileStream fst = new FileStream("customer.txt", FileMode.Open);

                BinaryFormatter f = new BinaryFormatter();

                customer c = new customer();

                while (fst.Position < fst.Length)
                {
                    c = (customer)f.Deserialize(fst);
                    if(c.e_mail==x&&c.password==y)
                    {
                       v= true;
                    }
                }
                fst.Close();
            }
            else
            {
                v = false;
            }
            return v;
        }

        //public bool check(string x)
        //{
        //    bool v = false;

        //    Dictionary<string, customer> list = new Dictionary<string, customer>();
        //    if (File.Exists("customer.txt"))
        //    {
        //        FileStream fst = new FileStream("customer.txt", FileMode.Open);

        //        BinaryFormatter f = new BinaryFormatter();

        //        customer c=new customer();

        //        while (fst.Position < fst.Length)
        //        {
        //            c = (customer)f.Deserialize(fst);
        //            list[c.e_mail] = c;
        //        }

        //        fst.Close();

        //        if (list.ContainsKey(x))
        //        {
        //            v = true;
        //        }


        //        list.Clear();

        //    }
        //    else
        //    {
        //        v = false;

        //    }

        //    return v;
 
        //}

        public void add(customer obj)
        {
            FileStream fs = new FileStream("customer.txt", FileMode.Append);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fs, obj);
            fs.Close();
        }
    }
}
