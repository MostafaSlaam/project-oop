using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS
{
    [Serializable]
   abstract class employee:person
    {
        public string id;
        public double salary;
        
        public employee()
        { }
        public employee(string name,int age,string address,string phone,string id,double salary,string sex)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
            this.id = id;
            this.salary = salary;
            this.sex = sex;
        }
        public abstract void add(string name, int age, string address, string phone, string id, double salary, string sex);
      

    }
}
