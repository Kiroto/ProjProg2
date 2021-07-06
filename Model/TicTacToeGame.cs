using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TicTacToeGame
    {
        TicTacToeTable table = new TicTacToeTable();
        Player playerOne = new Player('X');
        Player playerTwo = new Player('O');
        int turns = 0;
        bool isOneFirst = true;

        public void initialize()
        {
            turns = 0;
            table.initializeTable();
        }

        public char getGamespace(int posx, int posy)
        {
            return table.get(posx, posy);
        }

        bool playOnTable(int posx, int posy, Player plr)
        {
            if (!table.isSpaceTaken(posx, posy))
            {
                table.playOnField(posx, posy, plr.symbol);
                turns++;
                return true;
            }
            return false;
        }

        public bool playOnTable(int posx, int posy)
        {
            return playOnTable(posx, posy, playerFromNumber(getPlayer(turns)));
        }

        Player playerFromNumber(int playerNo)
        {
            return playerNo == 1 ? playerOne : playerNo == 2 ? playerTwo : throw new Exception("Jugador Invalido");
        }

        // return 0 if no win
        // return 1 if player 1 won
        // return 2 if player 2 won
        // return 3 if draw
        public int didPlayerWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (table.get(i, i) == table.DefaultSymbol)
                {
                    continue;
                }

                if (table.get(i, 0) == table.get(i, 1) && table.get(i, 0) == table.get(i, 2))
                {
                    return getPlayer(table.get(i, 0));
                }

                if (table.get(0, i) == table.get(1, i) && table.get(0, i) == table.get(2, i))
                {
                    return getPlayer(table.get(i, 0));
                }
            }

            if (
                (table.get(1, 1) != table.DefaultSymbol) && (
                table.get(0, 0) == table.get(1, 1) && table.get(0, 0) == table.get(2, 2) ||
                table.get(2, 0) == table.get(1, 1) && table.get(2, 0) == table.get(0, 2)
                ))
            {
                return getPlayer(table.get(1, 1));
            }

            return turns >= 9 ? 3 : 0;
        }

        private int getPlayer(char symbol)
        {
            if (symbol == playerOne.symbol)
            {
                return 1;
            }
            else if (symbol == playerTwo.symbol)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private int getPlayer(int turn)
        {
             return (turn + (isOneFirst ? 0 : 1)) % 2 + 1;
        }

        public char getCurrentPlayerSymbol()
        {
            return playerFromNumber(getPlayer(turns)).symbol;
        }
    }
}
