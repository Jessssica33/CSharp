using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class Stock
    {
        private int key;
        private string name;
        private int barCode;
        private float price;
        private int threshold;
        private int count;
        private int supplierKey;

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

        public int BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int SupplierKey
        {
            get { return supplierKey; }
            set { supplierKey = value; }
        }


        public override string ToString()
        {
            return "{" + key + "}" + name + ", " + barCode + ", " + price + ", " + threshold + ", " + count;
        }

    }
}
