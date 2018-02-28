using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    class Transaction
    {
        List<SoldItem> soldItemList;
        float total;

        public Transaction()
        {
            soldItemList = new List<SoldItem>();
            total = 0;
        }

        public float Total
        {
            set { total = value; }
            get { return total; }    
        }

        public void addSoldItem(Stock stock)
        {
            int notFound = 1;
            for (int i = 0; i < soldItemList.Count; ++i)
            {
                if (soldItemList[i].sameSoldItem(stock.BarCode))
                {
                    ++soldItemList[i].Count;
                    notFound = 0;
                }
            }

            if (notFound == 1)
            {
                SoldItem sItem = new SoldItem(stock);
                soldItemList.Add(sItem);
            }

            total += stock.Price;
        }

        public List<string> returnTotal()
        {
            List<string> t = new List<string>();

            for (int i = 0; i < soldItemList.Count; ++i)
            {
                t.Add(soldItemList[i].returnSoldItem());
            }

            t.Add("----------------");
            t.Add("Total: " + total);

            return t;
        }
    }
}
