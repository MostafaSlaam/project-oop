using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS
{
    [Serializable]
    abstract class person
    {
        public string sex;
        public string name;
        public int age;
        public string address;
        public string phone;
        public person()
        { }
        public person(string name,int age, string address,string phone,string sex)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
            this.sex = sex;
        }
    }
}
