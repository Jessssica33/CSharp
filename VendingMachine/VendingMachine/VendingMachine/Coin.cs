using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coin
    {
        private int money;
        private int count;
        private CoinDispenser coinDispenser;
        private int coinDispenserCount;
        private VMControl vm;

        public Coin(int money, int count, CoinDispenser coinDispenser, VMControl vm)
        {
            this.money = money;
            this.count = count;
            this.coinDispenser = coinDispenser;
            this.coinDispenserCount = 0;
            this.vm = vm;
        }

        public int getCount()
        {
            return count;
        }

        public void pushInsertCoin()
        {
            count++;
            vm.insertCoin(money);
        }

        public int calculateChange(int total)
        {
            int sum = 0;
            for (int i = 0; i < count; ++i)
            {
                sum += money;
                if (sum == total)
                {
                    coinDispenserCount = i + 1;
                    break;
                }
                else if (sum > total)
                {
                    coinDispenserCount = i;
                    break;
                }
            }

            if (sum < total)
            {
                coinDispenserCount = count;
            }

            return coinDispenserCount * money;
        }

        public void coinDispense()
        {
            count -= coinDispenserCount;
            coinDispenser.Actuate(coinDispenserCount);
            coinDispenserCount = 0;
        }


        public void coinReset(int count)
        {
            this.count = count;
            this.coinDispenserCount = 0;
        }
    }
}
