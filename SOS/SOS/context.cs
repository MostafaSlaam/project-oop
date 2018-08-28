using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS
{
    class context
    {
        public checker c;
        public context(checker obj)
        {
            c = obj;
        }
        public bool my_function(string x)
        {
            return c.check(x);
        }
    }
}
