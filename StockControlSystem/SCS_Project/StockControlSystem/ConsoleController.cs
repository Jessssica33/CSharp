using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StockControlSystem
{
    public class ConsoleController
    {
        Console console;
        // Add your fields
        private List<Supplier> supplierList;
        public List<Stock> stockList;
        private List<Order> orderList;
        private const int NUMBER_OF_SUPPLIER_ENTRIES_IN_LINE = 4;
        private const int NUMBER_OF_STOCK_ENTRIES_IN_LINE = 7;

        public ConsoleController(Console console)
        {
            this.console = console;
            supplierList = new List<Supplier>();
            stockList = new List<Stock>();
            orderList = new List<Order>();

        }

        public void ListStockItemsBelowThreshold_Handler()
        {
            console.ResetListDialog();
            Stock s;
            StringBuilder sBuilder = new StringBuilder();
            List<Stock> scarce = stockList.FindAll((Stock stock) => stock.ScarceFlag == 1);
            for (int i = 0; i < scarce.Count; ++i)
            {
                s = scarce[i];
                sBuilder.Clear();
                sBuilder.Append(s.returnScarce());
                sBuilder.Append(searchSupplier(s.SupplierKey));
                console.AppendItemsToListDialog(sBuilder.ToString());                
            }

            console.ShowListDialog();
        }
        public void ListAllSuppliers_Handler()
        {
            console.ResetListDialog();
            for (int i = 0; i < supplierList.Count; ++i)
            {
                console.AppendItemsToListDialog(supplierList[i].ToString());
            }
            console.ShowListDialog();
        }

        private string searchSupplier(int supplierKey)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < supplierList.Count; ++i)
            {
                if (supplierKey == supplierList[i].Key)
                {
                    s.Append(supplierList[i].ToString());
                }
            }

            return s.ToString();
        }

        public void ListAllStockItems_Handler()
        {
            StringBuilder sBuilder = new StringBuilder();
            console.ResetListDialog();
            for (int i = 0; i < stockList.Count; ++i)
            {
                sBuilder.Clear();

                sBuilder.Append(stockList[i].ToString());
                sBuilder.Append('[');
                sBuilder.Append(searchSupplier(stockList[i].SupplierKey));
                sBuilder.Append(']');

                console.AppendItemsToListDialog(sBuilder.ToString());
            }

            console.ShowListDialog();
        }

        public void Order_Handler()
        {
            string itemStr = console.GetItemKeyToOrder();
            string countStr = console.GetNumberOfItemsToOrder();
            if (!checkNumber(itemStr) || ! checkNumber(countStr))
            {
                console.DisplayErrorMessage("Please input a number");
                return;
            }

            int itemKey = Convert.ToInt32(itemStr);
            int count = Convert.ToInt32(countStr);

            console.ResetItemKeyToOrder();
            console.ResetNumberOfItemsToOrder();

            Stock stock = null;
            int notFound = 1;
            for (int i = 0; i < stockList.Count; ++i)
            {
                if (itemKey == stockList[i].Key)
                {
                    stock = stockList[i];
                    notFound = 0;
                    break;
                }
            }

            if (notFound == 1)
            {
                console.DisplayErrorMessage("Not Found Item");
                return;
            }

            addItemToOrderList(stock, count);           
        }

        private Supplier findSupplier(int supplierKey)
        {
            Supplier supplier = null;

            for (int i = 0; i < supplierList.Count; ++i)
            {
                if (supplierList[i].Key == supplierKey)
                {
                    supplier = supplierList[i];
                    break;
                }
            }

            return supplier;
        }

        private void addItemToOrderList(Stock stock, int count)
        {
            int notFound = 1;
            for (int i = 0; i < orderList.Count; ++i)
            {
                if (orderList[i].existOrder(stock.Key))
                {
                    orderList[i].Count += count;
                    notFound = 0;
                    break;
                }
            }

            if (notFound == 1)
            {
                Supplier s = findSupplier(stock.SupplierKey);
                if (s != null)
                {
                    Order order = new Order(stock, count, s);
                    orderList.Add(order);
                }
            }
        }

        public void ListOutstandingOrders_Handler()
        {
            console.ResetListDialog();

            for (int i = 0; i < orderList.Count; ++i)
            {
                console.AppendItemsToListDialog(orderList[i].returnCurrentOrder());
            }

            console.ShowListDialog();
        }

        private void restock(int itemKey, int count)
        {
            for (int i = 0; i < stockList.Count; ++i)
            {
                if (itemKey == stockList[i].Key)
                {
                    stockList[i].Count += count;
                    break;
                }
            }
        }

        private bool checkNumber(string str)
        {
            if (str.Length == 0)
            {
                return false;
            }

            char[] s = str.ToCharArray();

            for (int i = 0; i < str.Length; ++i)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void Restock_Handler()
        {
            string str = console.GetItemKeyToRestock();
            if (!checkNumber(str))
            {
                console.DisplayErrorMessage("Please input a number");
                return;
            }

            int itemKey = Convert.ToInt32(str);
            int notFount = 1;

            console.ResetItemKeyToRestock();

            for (int i = 0; i < orderList.Count; ++i)
            {
                if (orderList[i].existOrder(itemKey))
                {
                    restock(itemKey, orderList[i].Count);
                    orderList.RemoveAt(i);
                    notFount = 0;
                    break;
                }
            }

            if (notFount == 1)
            {
                console.DisplayErrorMessage("Not Found Item");
            }
        }

        private void loadStock(string[] e)
        {
            Stock stock = new Stock();
            for (int i = 0; i < 7; ++i)
            {
                string s = e[i].Trim();                
                switch (i)
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

        public void LoadStockItems_Handler(string fileName)
        {
            string s;
            string[] properties = new string[NUMBER_OF_SUPPLIER_ENTRIES_IN_LINE];
            char[] spliter = { '&' };
            TextReader trs = new StreamReader(fileName);
            while (((s = trs.ReadLine()) != null) && s != "")
            {
                properties = s.Split(spliter);
                loadStock(properties);
            }
        }

        

        private void loadSupplier(string[] e)
        {
            Supplier supplier = new Supplier();
            for (int i = 0; i < 4; ++i)
            {
                string s = e[i].Trim();
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

        public void LoadSuppliers_Handler(string fileName)
        {
            string s;
            string[] properties = new string[NUMBER_OF_STOCK_ENTRIES_IN_LINE];
            char[] spliter = { '&' };

            TextReader trs = new StreamReader(fileName);
            while (((s = trs.ReadLine()) != null) && s != "")
            {
                properties = s.Split(spliter);
                loadSupplier(properties);
            }
        }
    }
}
