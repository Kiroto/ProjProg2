using System;
using System.Collections.Generic;

namespace Model
{
    public class TicTacToeTable
    {
        private List<List<Char>> playTable = new List<List<Char>>();
        public char DefaultSymbol = ' '; 

        public void initializeTable()
        {
            playTable = new List<List<Char>>();
            for (int i = 0; i < 3; i++)
            {
                playTable.Add(new List<Char>());
                for (int k = 0; k < 3; k++)
                {
                    playTable[i].Add(DefaultSymbol);
                }
            }
        }

        public void playOnField(int posx, int posy, char symbol)
        {
            playTable[posy][posx] = symbol;
        }

        public bool isSpaceTaken(int posx, int posy)
        {
            return playTable[posy][posx] != DefaultSymbol;
        }

        public char get(int posx, int posy)
        {
            return playTable[posy][posx];
        }
    }
}
