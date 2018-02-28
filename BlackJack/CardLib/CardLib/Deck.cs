using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class Deck
    {
        private Card[] deck;
        private int topCard;
        private Random random = new Random();

        public Deck()
        {
            int rank = 0;
            int suit = 0;

            deck = new Card[52];
            int i = 0;
            while (i < 52)
            {
                rank = random.Next(13) + 1;
                suit = random.Next(4);
                if (checkRepeat(rank, (Card.CardSuit)suit, i) == false)
                {
                    Card c = new Card(rank, (Card.CardSuit)suit);
                    deck[i] = c;
                    ++i;
                }

            }

            topCard = i - 1;
        }

        private bool checkRepeat(int rank, Card.CardSuit suit, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                if (deck[i].rank == rank && deck[i].suit == suit)
                {
                    return true;
                }
            }

            return false;
        }

        public void shuffle()
        {
            int j = 0;
            Card tmp;
            for (int i = 0; i < deck.Length; ++i)
            {
                j = random.Next(i, deck.Length);
                tmp = deck[i];
                deck[i] = deck[j];
                deck[j] = tmp;

            }
        }

        public void returnCards(params Card[] cards)
        {            
            for (int i = 0; i < cards.Length; ++i)
            {
                deck[++topCard] = cards[i];              
            }
        }

        public Card draw(string prompt)
        {
#if DEBUG
            string str = CardGame.getCardString(prompt);

            if (str == "xx" || str == "XX")
            {
                return deck[topCard--];
            }

            for (int i = 0; i <= topCard; ++i)
            {
                if (str == deck[i].ToString())
                {
                    Card c = deck[i];
                    deck[i] = deck[topCard];
                    deck[topCard] = c;
                    break;                   
                }
            }

            return deck[topCard--];
#else
            return deck[topCard--];
#endif
        }

        //check if the str represent card in the deck.
        public bool checkValid(string str)
        {
            for (int i = 0; i <= topCard; ++i)
            {
                if (str == deck[i].ToString())
                {
                    return true;
                }
            }

            return false;
        }


        public string printWholeCards()
        {
            StringBuilder s = new StringBuilder();
            int i = 0;
            for (i = 0; i <= topCard; ++i)
            {
                s.Append(deck[i].ToString());
                s.Append(" ");
            }

            s.Append(topCard);

            return s.ToString();
        }

    }
}
