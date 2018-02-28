using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace BlackJackGame
{
    public class BlackJack : CardGame
    {
        Player p;
        Player d;
        int betAmount = 0;
        int numUserWins = 0;
        int numdealerWins = 0;
        int numTies = 0;
        public BlackJack(ITerminal terminal): base(terminal)
        {
            p = new Player(100, deck);
            d = new Player(2000000, deck);
        }

        void getUsersBet()
        {
            betAmount = terminal.getInt("How much money would you like to bet? Please input a number between 10 to 200.", 10, 200);
        }

        void dealCards()
        {
         
#if DEBUG
            p.deal(deck.draw("Please input a card for Player, like AS: "));
            d.deal(deck.draw("Please input a card for Dealer, like AS: "));
            p.deal(deck.draw("Please input a card for Player, like AS: "));
            d.deal(deck.draw("Please input a card for Dealer, like AS: "));
#else
            p.deal(deck.draw(""));
            d.deal(deck.draw(""));
            p.deal(deck.draw(""));
            d.deal(deck.draw(""));
#endif
        }

        //If bust return true, else return false.
        bool userTurnAndCheckBust()
        {
            while (true)
            {
                char c = terminal.getChar("Do you want one more card?[Y/N]", "YyNn");
                if (c == 'Y' || c == 'y')
                {
#if DEBUG
                    p.deal(deck.draw("Please input a card for Player, like AS: "));
#else
                    p.deal(deck.draw(""));
#endif
                    terminal.display(p.ToString());
                }
                else
                {
                    break;
                }
            }

            if (p.checkBust())
            {
                
                return true;
            }

            return false;

        }

        //If bust return true, else return false.
        bool dealerTurnAndCheckBust()
        {
            while (true)
            {
                terminal.display(d.ToString());
                if (d.higherThan17())
                {
                    if (d.checkBust())
                    {
                        
                        return true;
                    }

                    return false;
                }

#if DEBUG              
                d.deal(deck.draw("Please input a card for Dealer, like AS: "));
#else
                d.deal(deck.draw(""));
#endif

            }
        }

        //0: dealer win, 1: player win, 2: tie
        int playOneGame()
        {
            getUsersBet();         
            dealCards();
            terminal.display(p.ToString());

            if (p.testNatural21())
            {
                if (d.testNatural21())
                {
                    ++numTies;                   
                    return 2;
                }
                else
                {
                    terminal.display("Player get natural 21");
                    ++numUserWins;                
                    return 1;
                }
            }

            if (userTurnAndCheckBust())
            {
                terminal.display("Player bust!!!");
                ++numdealerWins;         
                return 0;
            }

            if (dealerTurnAndCheckBust())
            {
                terminal.display("Dealer bust!!!");
                ++numUserWins;              
                return 1;
            }

            if (d.handValue > p.handValue)
            {
                ++numdealerWins;            
                return 0;
            }
            else if (d.handValue == p.handValue)
            {
                ++numTies;               
                return 2;
            } 
            else
            {
                ++numUserWins;                
                return 1;
            }

        }

        //True: player bankrupt, false: player is not bankrupt.
        bool displayResultAndCheckBankrupt(int r)
        {
            if (r == 0)
            {
                p.money -= betAmount;
                d.money += betAmount;   
                terminal.display("Dealer win.");
            }
            else if (r == 1)
            {
                if (p.testNatural21())
                {
                    p.money += betAmount * 2;
                    d.money -= betAmount * 2;
                }
                else
                {
                    p.money += betAmount;
                    d.money -= betAmount;
                }
                terminal.display("Player win.");
            }
            else
            {
                terminal.display("Tie");
            }

            terminal.display(showResult());

            if (p.money <= 0)
            {
                terminal.display("Player bankrupt!");
                return true;
            }

            return false;
        }

        bool checkMoreGame()
        {
            while (true)
            {
                char c = terminal.getChar("Do you want to start a new game?[Y/N]", "YyNn");
                if (c == 'Y' || c == 'y')
                {
                    return true;
                }
                else if (c == 'N' || c == 'n')
                {
                    return false;
                }

            }
        }

        string showResult()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Number of Player Win: " + numUserWins);
            s.Append("\nNumber of Dealer Win: " + numdealerWins);
            s.Append("\nNumber of Tie: " + numTies);
            s.Append("\nPlayer balance: " + p.money);

            return s.ToString();
        }
        void resetGame()
        {            
            p.reset();          
            d.reset();           
            deck.shuffle();
         
        }
        public void play()
        {
            int r = 0;

            while (true)
            {               
                r = playOneGame();
                
                if (displayResultAndCheckBankrupt(r))
                    return;
                if (!checkMoreGame())
                    return;
              
                resetGame();            
            }

            
        }

        static void Main(string[] args)
        {
            ITerminal it = new ConsoleTerminal();
            BlackJack bj = new BlackJack(it);

            bj.play();

        }
    }
}
