using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockControlSystem
{
    public class TillController
    {
        Till till;
        // Add necessary fields
        List<Transaction> transList;
        Transaction currentTrans;

        public TillController(Till till)
        {
            this.till = till;
            transList = new List<Transaction>();
            currentTrans = new Transaction();
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
        public void BarCodeScan_Handler()
        {           
            string barString = till.GetBarCode();
            if (!checkNumber(barString))
            {
                till.DisplayErrorMessage("Please input a number");
                return;
            }

            int barCode = Convert.ToInt32(barString);
            Stock stock;
            int notFound = 1;           
            for (int i = 0; i < till.stockList.Count; ++i)
            {
                stock = till.stockList[i];
                if (barCode == stock.BarCode && stock.Count > 0)
                {
                    till.DisplayItemNameAndPrice(stock.Name, stock.Price.ToString());
                    till.ResetBarCode();

                    currentTrans.addSoldItem(stock);
                    stock.Count--;
                    stock.setScarceFlag();
                    notFound = 0;
                }
            }

            if (notFound == 1)
            {
                till.DisplayErrorMessage("Not Fount Item");
            }

        }

    
        public void Total_Handler()
        {            
            List<string> total = currentTrans.returnTotal();

            till.ResetListDialog();
            till.AppendItemsToListDialog(total.ToArray());
            till.ShowListDialog();

            transList.Add(currentTrans);
            this.currentTrans = new Transaction();
        }

        public void Balance_Handler()
        {
            float balance = 0;
            till.ResetListDialog();

            for (int i = 0; i < transList.Count; ++i)
            {
                balance += transList[i].Total;
                till.AppendItemsToListDialog(transList[i].returnTotal().ToArray());
            }

            till.AppendItemsToListDialog("======================");
            till.AppendItemsToListDialog("Total of the Day = " + balance.ToString());
           
            till.ShowListDialog();
        }

        public void TransactionClear_Handler()
        {
            transList.Clear();
        }
    }
}
