using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class Supplier
    {
        private int key;
        private string name;
        private string address;
        private string phone;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public override string ToString()
        {
            return key + ": " + name + ", " + Address + ", " + phone;
        }
    }
}
