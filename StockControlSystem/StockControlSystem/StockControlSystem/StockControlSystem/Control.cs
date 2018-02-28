using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    public class Control
    {
        private List<Supplier> supplierList;
        private List<Stock> stockList;

        public Control()
        {
            supplierList = new List<Supplier>();
            stockList = new List<Stock>();
        }

        public void loadSupplier(string[] entity)
        {
            Supplier supplier = new Supplier();
            for (int i = 0; i < 4; ++i)
            {
                string s = entity[i].Trim();
                if (i == 0)
                {
                    supplier.Key = Convert.ToInt32(s);
                }
                else if (i == 1)
                {
                    supplier.Name = s;
                }
                else if (i == 2)
                {
                    supplier.Address = s;
                }
                else if (i == 3)
                {
                    supplier.Phone = s;
                }
            }
            supplierList.Add(supplier);
        }

        public void loadStock(string[] entity)
        {
            Stock stock = new Stock();
            for (int i = 0; i < 7; ++i)
            {
                string s = entity[i].Trim();
                switch(i)
                {
                    case 0:
                        stock.Key = Convert.ToInt32(s);
                        break;
                    case 1:
                        stock.Name = s;
                        break;
                    case 2:
                        stock.BarCode = Convert.ToInt32(s);
                        break;
                    case 3:
                        stock.Price = Convert.ToSingle(s);
                        break;
                    case 4:
                        stock.Threshold = Convert.ToInt32(s);
                        break;
                    case 5:
                        stock.Count = Convert.ToInt32(s);
                        break;
                    case 6:
                        stock.SupplierKey = Convert.ToInt32(s);
                        break;
                    default:
                        break;
                }

            }

            stockList.Add(stock);
        }
    }
}
