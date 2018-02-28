using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VMControl
    {
        public  List<Can> canList = new List<Can>();
        public  List<Coin> coinList = new List<Coin>();

        private int totalInsertMoney;
        private TimerLight noChangeLight;
        private AmountDisplay amountDisplay;
        
        public VMControl(TimerLight noChangeLight, AmountDisplay amountDisplay)
        {
            this.noChangeLight = noChangeLight;
            this.amountDisplay = amountDisplay;
            totalInsertMoney = 0;
        }

        public void insertCoin(int money)
        {
            totalInsertMoney += money;
            amountDisplay.DisplayAmount(totalInsertMoney);
            for (int i = 0; i < canList.Count; ++i)
            {
                canList[i].checkPurchasableLight(totalInsertMoney);
            }        
        }

        public void turnOffPurchaseableLight()
        {
            for (int i = 0; i < canList.Count; ++i)
            {
                canList[i].turnOffPurchasableLight();
            }
        }

        private void turnOffSoldOutLight()
        {
            for (int i = 0; i < canList.Count; ++i)
            {
                canList[i].turnOffSoldOutLight();
            }
        }

        public int getTotalInsertMoney()
        {
            return totalInsertMoney;
        }

        public bool checkIfReturnChange(int price)
        {
            int tmp = totalInsertMoney - price;
           
            for (int i = coinList.Count - 1; i >= 0; --i)
            {
                tmp -= coinList[i].calculateChange(tmp);
            }

            if (tmp == 0)
            {
                totalInsertMoney = 0;
                return true;
            }

            noChangeLight.TurnOn3Sec();
            return false;
        }

        public void coinDispense()
        {
            for (int i = 0; i < coinList.Count; ++i)
            {
                coinList[i].coinDispense();
            }
            amountDisplay.DisplayAmount(totalInsertMoney);
        }


        public void coinReturn()
        {
            checkIfReturnChange(0);
            coinDispense();
            turnOffPurchaseableLight();
          
        }

        public void reset()
        {
            for (int i = 0; i < canList.Count; ++i)
            {
                canList[i].canReset();
            }

            coinList[0].coinReset(15);
            coinList[1].coinReset(10);
            coinList[2].coinReset(5);
            coinList[3].coinReset(2);
            turnOffPurchaseableLight();
            turnOffSoldOutLight();
            totalInsertMoney = 0;
            amountDisplay.DisplayAmount(totalInsertMoney);
        }

    }
}
