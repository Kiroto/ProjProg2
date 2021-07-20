using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace GameConsole
{
    class TicTacToeConsole
    {
        const char gridChar = '#';
        const int cubicleSize = 7;

        TicTacToeGame tttg = new TicTacToeGame();

        public void playGame()
        {
            tttg.initialize();
            drawTable();
            int win = 0;
            while(win == 0)
            {
                drawContents();
                Console.SetCursorPosition((cubicleSize + 1) * 3 + 3, cubicleSize+4);
                Console.Write("Player " + tttg.getCurrentPlayerSymbol() + "'s turn");
                Console.SetCursorPosition((cubicleSize + 1) * 3 + 3, cubicleSize + 5);
                Console.Write("Write 1-9 depending in where you want to play");
                Console.SetCursorPosition((cubicleSize + 1) * 3 + 3, cubicleSize + 6);
                int play = -1;
                string usrinput = Console.ReadLine();
                int.TryParse(usrinput, out play);
                if (play < 1 || play > 9)
                {
                    Console.SetCursorPosition((cubicleSize + 1) * 3 + 3, cubicleSize + 7);
                    Console.Write("Please write a number between 1-9");
                }
                tryPlay(play);
                win = tttg.didPlayerWin();
            }
            drawContents();
            Console.SetCursorPosition((cubicleSize + 1) * 3 + 3, (cubicleSize + 1) * 3 + 3);
            switch (win)
            {
                case 1:
                    Console.Write("Player X Wins!");
                    break;
                case 2:
                    Console.Write("Player O Wins!");
                    break;
                case 3:
                    Console.Write("It's been a draw!");
                    break;
            }
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }

        private void tryPlay(int number)
        {
            switch(number)
            {
                case 1:
                    tttg.playOnTable(0, 0);
                    break;
                case 2:
                    tttg.playOnTable(1, 0);
                    break;
                case 3:
                    tttg.playOnTable(2, 0);
                    break;
                case 4:
                    tttg.playOnTable(0, 1);
                    break;
                case 5:
                    tttg.playOnTable(1, 1);
                    break;
                case 6:
                    tttg.playOnTable(2, 1);
                    break;
                case 7:
                    tttg.playOnTable(0, 2);
                    break;
                case 8:
                    tttg.playOnTable(1, 2);
                    break;
                case 9:
                    tttg.playOnTable(2, 2);
                    break;
            }
        }

        private void drawTable()
        {
            Console.Clear();
            for (int i = 0; i < cubicleSize * 3 + 2; i++)
            {
                Console.SetCursorPosition(cubicleSize, i);
                Console.Write(gridChar);
                Console.SetCursorPosition((cubicleSize) * 2 +1 , i);
                Console.Write(gridChar);
                Console.SetCursorPosition(i, cubicleSize);
                Console.Write(gridChar);
                Console.SetCursorPosition(i, (cubicleSize) * 2 + 1);
                Console.Write(gridChar);
            }
        }

        private void drawContents()
        {
            for (int x = 0; x < 3; x++)
                for(int y = 0; y < 3; y++)
                {
                    int xpos = (x * cubicleSize + 1) + 3;
                    int ypos = (y * cubicleSize + 1) + 3;
                    char element = tttg.getGamespace(x, y);
                    Console.SetCursorPosition(xpos, ypos);
                    if (element == ' ')
                    {
                        element = (1 + x + y * 3).ToString()[0];
                    }
                    Console.Write(element);
                }
        }
    }
}
