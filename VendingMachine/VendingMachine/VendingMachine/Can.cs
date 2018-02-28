using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Can
    {
        private string name;
        private int price;
        private int count;
        private Light soldOutLight;
        private Light purchasableLight;
        private CanDispenser canDispenser;
        private VMControl vm;

        public Can(string name, int price, int count, Light purchasableLight, Light soldOutLight, CanDispenser canDispenser, VMControl vm)
        {
            this.name = name;
            this.price = price;
            this.count = count;
            this.purchasableLight = purchasableLight;
            this.soldOutLight = soldOutLight;
            this.canDispenser = canDispenser;
            this.vm = vm;
        }

        public int getCount()
        {
            return count;
        }

        public void checkPurchasableLight(int totalInsertMoney)
        {
            if (totalInsertMoney >= price && count > 0)
            {
                purchasableLight.TurnOn();
            }
        }

        public void turnOffPurchasableLight()
        {
            purchasableLight.TurnOff();
        }
        
        public void turnOffSoldOutLight()
        {
            soldOutLight.TurnOff();
        }

        public void pushPurchaseButton()
        {
            if (vm.getTotalInsertMoney() >= price && count > 0)
            {
                vm.turnOffPurchaseableLight();
                if (vm.checkIfReturnChange(price))
                {
                    count--;
                    canDispenser.Actuate();
                    if (count == 0)
                    {
                        soldOutLight.TurnOn();                       
                    }
                    vm.coinDispense();
                }
                
            }
        }

        public void canReset()
        {
            count = 4;
        }
    }
}
