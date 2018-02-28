//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        //int coinType; //0: 10, 1: 50, 2: 100, 3: 500
        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        Coin coin;

        public CoinInserter()
        {

        }
        public CoinInserter(Coin coin)
        {
            this.coin = coin;
        }
        public void CoinInserted()
        {
            // You can add only one line here
            coin.pushInsertCoin();
        }

    }

    public interface VMButton
    {
        void ButtonPressed();
    }

    public class PurchaseButton : VMButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        Can can;

        public PurchaseButton()
        {

        }
        public PurchaseButton(Can can)
        {
            this.can = can;
        }
        public void ButtonPressed()
        {
            // You can add only one line here
            can.pushPurchaseButton();
        }
    }

    public class CoinReturnButton : VMButton
    {
        // add a field to specify an object that Button Pressed will visit
        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field
        VMControl vm;

        public CoinReturnButton()
        {

        }
        public CoinReturnButton(VMControl vm)
        {
            this.vm = vm;
        }
        public void ButtonPressed()
        {
            // You can add only one lines here
            vm.coinReturn();
        }
    }

    public class SalesRecordListButton : VMButton
    {
        // add a field to specify an object that ButtonPressed will visit
        public SalesRecordListButton()
        {
        }
        public void ButtonPressed()
        {
            // You can add only one line herer
        }
    }

    public class SalesRecordClearButton : VMButton
    {
        // add a field to specify an object that ButtonPressed will visit 
        public SalesRecordClearButton()
        {
        }

        public void ButtonPressed()
        {
            // You can add only one line here
        }
    }
}
