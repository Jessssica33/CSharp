using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;


namespace BlackJackGame
{
    class Player
    {
        protected List<Card> hand = new List<Card>();
        protected StringBuilder handString = new StringBuilder();

        public int handValue = 0;
        public int money = 0;

        //the count of card A
        private int aCount = 0;
        private Deck deck;


        public Player(int m, Deck d)
        {
            deck = d;
            money = m;
        }

        public void deal(Card c)
        {
            hand.Add(c);
            int score = c.rank;

            dealHandValue(score);

            handString.Append(c.ToString());
            handString.Append(" ");

        }

        public bool testNatural21()
        {
            if (handValue == 21 && hand.Count == 2)
            {
                return true;
            }

            return false;
        }

        public bool checkBust()
        {
            if (handValue > 21)
            {
                return true;
            }

            return false;
        }

        public bool higherThan17()
        {
            if (handValue >= 17)
            {
                return true;
            }

            return false;
        }
        private void dealHandValue(int score)
        {
            if (score > 10)
            {
                score = 10;
            }

            if (score == 1 && (11 + handValue <= 21))
            {
                score = 11;
                ++aCount;
            }

            handValue += score;

            if (handValue > 21 && aCount > 0)
            {
                handValue -= 10;
                --aCount;
            }

        }

        public string ToString()
        {
            return handString.ToString();
        }

        public void reset()
        {           
            Card[] c = new Card[hand.Count];
            
            for (int i = 0; i < hand.Count; ++i)
            {
                c[i] = hand[i];             
            }
       
            deck.returnCards(c);
       
            handValue = 0;       
            handString.Clear();           
            hand.RemoveRange(0, hand.Count);        
        }

    }
}
