using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class CardGame
    {
        public static Deck deck;
        public static ITerminal terminal;

        public CardGame(ITerminal terminal)
        {
            deck = new Deck();
            CardGame.terminal = terminal;
        }

        //This function must be static, because deck.draw() use it without a object.
        public static string getCardString(string prompt)
        {
            string str;
            while (true)
            {
                str = terminal.getString(prompt, 2);
                if (deck.checkValid(str) == true)
                {
                    return str;
                }

                display("The card is not in deck now.");
            }
        }

        static void display(string s)
        {
            terminal.display(s);
        }
    }
}
