using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    
    public class Card
    {
        private char[] cRank = {'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
        private char[] cSuit = {'H', 'D', 'C', 'S'};

        public int rank = 0; //from 1 to 13
        public CardSuit suit = 0; //from 0 to 3

        public enum CardSuit : uint { Hearts, Diamonds, Clubs, Spaces };
        public Card(int r, CardSuit s)
        {
            this.rank = r;
            this.suit = s;
        }

        public string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(cRank[rank - 1]);
            s.Append(cSuit[(int)suit]);
            string str = s.ToString();
            return str;
        }

    }
}
