using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public interface ITerminal
    {
        void display(string s);
        char getChar(string prompt, string chars);
        int getInt(string prompt, int min, int max);
        string getString(string prompt, int length);
    }
}
