using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    class Order
    {
        Stock stock;
        DateTime now;
        int count;
        Supplier supplier;

        public Order(Stock stock, int count, Supplier supplier)
        {
            this.stock = stock;
            this.count = count;
            this.supplier = supplier;
            now = DateTime.Now;
        }

        public int Count
        {
            set { count = value; }
            get { return count; }
        }

        public bool existOrder(int key)
        {
            if (key == stock.Key)
            {
                return true;
            }

            return false;
        }

        public string returnCurrentOrder()
        {
            StringBuilder str = new StringBuilder();

            System.Console.WriteLine(now.ToString());
            str.Append(now.ToString());
            str.Append(" " + "[" + count + "]" + ": ");
            str.Append("{" + stock.Key + "}" + " ");
            str.Append(stock.Name + " ");
            str.Append(stock.Count + "/");
            str.Append(stock.Threshold + " ");
            str.Append(supplier.ToString());

            return str.ToString();
        }
    }
}
