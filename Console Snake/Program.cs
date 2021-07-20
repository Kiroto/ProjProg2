using System;
using System.Threading;

namespace Console_Snake
{
    public class Snake
    {
        const int BoardHeight = 20;
        const int BoardWidth = 30;
        const int InitialSnakeSize = 3;
        const int FruitNumber = -1;
        const int InitialX = BoardWidth / 2;
        const int InitialY = BoardHeight / 2;

        const char snakeChar = 'O';
        const char fruitChar = '@';
        const char wallChar = '#';
        const char emptyChar = ' ';

        Random rnd = new Random();

        int[,] Board = new int[BoardHeight, BoardWidth];
        int SnakeSize = InitialSnakeSize;
        int xpos = InitialX;
        int ypos = InitialY;
        int direction = 0;

        public Snake()
        {
            WriteWalls();
            Console.CursorVisible = false;
            Board[ypos, xpos] = SnakeSize;
            SetNextFruit();
        }

        public void SetNextFruit()
        {
            Board[rnd.Next(BoardHeight), rnd.Next(BoardWidth)] = FruitNumber;
        }

        public void WriteWalls()
        {
            Console.Clear();
            for(int x = 0; x <= BoardWidth; x++)
            {
                Console.SetCursorPosition(x,0);
                Console.Write(wallChar);
                Console.SetCursorPosition(x, BoardHeight+1);
                Console.Write(wallChar);
            }
            for (int y = 0; y <= BoardHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(wallChar);
                Console.SetCursorPosition(BoardWidth + 1, y);
                Console.Write(wallChar);
            }
        }

        public void WriteBoard()
        {
            for (int y = 0; y < BoardHeight; y++)
                for (int x = 0; x < BoardWidth; x++)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    if (Board[y,x] == 0)
                    {
                        Console.Write(emptyChar);
                    }
                    else if (Board[y, x] == FruitNumber)
                    {
                        Console.Write(fruitChar);
                    } else
                    {
                        Console.Write(snakeChar);
                    }
                }
        }
        
        private bool InBounds()
        {
            return InBounds(ypos, xpos);
        }

        private bool InBounds(int y, int x)
        {
            return y >= 0 && y < BoardHeight && x >= 0 && x < BoardWidth;
        }

        public void Input()
        {
            if (Console.KeyAvailable && InBounds())
            {
                char key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case 'w':
                        if (direction != 2)
                            direction = 0;
                        break;
                    case 's':
                        if (direction != 0)
                            direction = 2;
                        break;
                    case 'd':
                        if (direction != 3)
                            direction = 1;
                        break;
                    case 'a':
                        if (direction != 1)
                            direction = 3;
                        break;
                }
                
            }
        }

        public int GetScore()
        {
            return SnakeSize - 3;
        }

        public bool Logic()
        {
            for (int y = 0; y < BoardHeight; y++)
                for (int x = 0; x < BoardWidth; x++)
                {
                    if (Board[y, x] > 0)
                    {
                        Board[y, x]--;
                    }
                }
            Thread.Sleep(100);

            switch (direction)
            {
                case 0: ypos--; break;
                case 2: ypos++; break;
                case 1: xpos++; break;
                case 3: xpos--; break;
            }
            

            if (!InBounds())
            {
                return true;
            }
            else if (Board[ypos, xpos] == FruitNumber)
            {
                Board[ypos, xpos] = 0;
                SnakeSize++;
                SetNextFruit();
            }
            if (Board[ypos, xpos] == 0)
                Board[ypos, xpos] = SnakeSize;
            else
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
            }
        }
    }
}
