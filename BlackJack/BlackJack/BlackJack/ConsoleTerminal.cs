using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLib;

namespace BlackJackGame
{
    class ConsoleTerminal: ITerminal
    {
        void ITerminal.display(string s)
        {
            Console.WriteLine(s + '\n');
        }

        char ITerminal.getChar(string prompt, string chars)
        {
            string s;
            char ch;
            while (true)
            {
                Console.WriteLine(prompt);
                s = Console.ReadLine();
              
                if (s.Length == 1 && chars.IndexOf(s) > 0)
                {
                    ch = s[0];
                    return ch;
                }
            }
        }

        int ITerminal.getInt(string prompt, int min, int max)
        {
            int m = 0;
            while (true)
            {               
                Console.WriteLine(prompt);
                m = Convert.ToInt32(Console.ReadLine());
                if (min == 0 && max == 0)
                {
                    return m;
                }

                if (min!= 0 && max != 0 && m <= max && m >= min)
                {
                    return m;
                }
            }
        }

        string ITerminal.getString(string prompt, int length)
        {
            string str;
            while (true)
            {
                Console.WriteLine(prompt);
                str = Console.ReadLine();

                if (length == 0)
                {
                    return str;
                }
                else if (str.Length == length)
                {
                    return str;
                }

                
            }
        }
    }
}
