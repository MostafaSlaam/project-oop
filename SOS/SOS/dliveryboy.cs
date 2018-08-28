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
    class dliveryboy:employee
    {
        
        public List<string> date1=new List<string> ();
        public List<string> date2=new List<string> ();
        public dliveryboy()
        {  
        }
        public dliveryboy(string name, int age, string address, string phone, string id, double salary,string sex)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
            this.id = id;
            this.salary = salary;
            this.sex = sex;
            DateTime d1 = DateTime.Today;
            DateTime d2 = DateTime.Today;
            date1.Add(d1.ToString());
            date2.Add(d2.ToString());
         }
        public override void add(string name, int age, string address, string phone, string id, double salary, string sex)
             {
                 dliveryboy d = new dliveryboy(name,age,address,phone,id,salary,sex);
                 FileStream fs = new FileStream("dliveryboy.txt", FileMode.Append);
                 BinaryFormatter f = new BinaryFormatter();
                 f.Serialize(fs, d);
                 fs.Close();
        }
        public string assgin()
        {
            DateTime da = DateTime.Now;
            FileStream fs = new FileStream("dliveryboy.txt", FileMode.Open);
            BinaryFormatter f = new BinaryFormatter();
            dliveryboy d = new dliveryboy();
            while(fs.Position<fs.Length)
            {
                d = (dliveryboy)f.Deserialize(fs);
                if (!d.date1.Contains(da.ToString()))
                {
                    fs.Close();
                    d.add_date(d.name, da);
                    return d.name;
                }
                else if(!d.date2.Contains(da.ToString()))
                {
                    fs.Close();
                    d.add_date(d.name,da);
                    return d.name;
                }
            }

            return null;
        }

        public void add_date(string n,DateTime d)
        {
            FileStream fs = new FileStream("dliveryboy.txt",FileMode.Open);
            BinaryFormatter f = new BinaryFormatter();
            Dictionary<string, dliveryboy> list = new Dictionary<string, dliveryboy>();
            while(fs.Position<fs.Length)
            {
                dliveryboy boy = (dliveryboy)f.Deserialize(fs);
                list[boy.name] = boy;
            }
            fs.Close();
            if (list[n].date1.Contains(d.ToString()))
            {
                list[n].date2.Add(d.ToString());
            }
            else { list[n].date1.Add(d.ToString()); }
            FileStream formatt = new FileStream("dliveryboy.txt",FileMode.Truncate);
            formatt.Close();
            FileStream file = new FileStream("dliveryboy.txt", FileMode.Append);
            for (int i = 0; i < list.Count;i++)
            {
                f.Serialize(file, list.ElementAt(i).Value);
            }
            file.Close();
        }
    }
}
