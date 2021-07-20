using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Player
    {
        public string name = "";
        public char symbol = 'D';

        public Player(char newSymbol)
        {
            symbol = newSymbol;
        }
    }
}
