using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    class SoldItem
    {
        Stock stock;
        int count;

        public SoldItem(Stock stock)
        {
            this.stock = stock;
            this.count = 1;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool sameSoldItem(int barCode)
        {
            if (stock.BarCode == barCode)
            {
                return true;
            }

            return false;
        }

        public string returnSoldItem()
        {
            return stock.Name + ": " + stock.Price + "----" + count;
        }

    }
}
