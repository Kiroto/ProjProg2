using System;

namespace GameConsole
{
    class Program
    {
        static ConsoleColor defaultForeground = ConsoleColor.White;
        static ConsoleColor defaultBackground = ConsoleColor.Black;
        static readonly ConsoleKey OK = ConsoleKey.Enter;
        static readonly ConsoleKey UP = ConsoleKey.UpArrow;
        static readonly ConsoleKey DOWN = ConsoleKey.DownArrow;

        enum Alignment
        {
            Left,
            Center,
            Right
        }

        static void writeText(String text, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null, Alignment al = Alignment.Left)
        {
            Console.BackgroundColor = (bgColor != null ? bgColor.Value : defaultBackground);
            Console.ForegroundColor = (fgColor != null ? fgColor.Value : defaultForeground);

            switch (al)
            {
                case Alignment.Right:
                    Console.SetCursorPosition(Console.WindowWidth - text.Length, Console.CursorTop);
                    break;
                case Alignment.Center:
                    ConsoleHelpers.centerComponentH(text.Length);
                    break;
                case Alignment.Left:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    break;
            }

            Console.WriteLine(text);

            Console.BackgroundColor = defaultBackground;  
            Console.ForegroundColor = defaultForeground;
        }

        static int optionsWindow(String[] options, int positionX, int positionY = 3)
        {
            OptionsMenu optionsMenu = new OptionsMenu(options, positionX, positionY);
            Console.CursorVisible = false;
            ConsoleKey keyPressed = ConsoleKey.NoName;
            while (keyPressed != OK)
            {
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == UP)
                    optionsMenu.cursorUp();
                if (keyPressed == DOWN)
                    optionsMenu.cursorDown();
                optionsMenu.Draw();
            }
            optionsMenu.Dispose();
            Console.CursorVisible = true;
            return optionsMenu.cursor;
        }


        static void Main(string[] args)
        {
            writeText("What Game would you like to play?", bgColor: ConsoleColor.DarkYellow, al: Alignment.Center);
            String[] options = { "Tic-Tac-Toe", "Three And Two", "Exit" };
            int selection = optionsWindow(options, ConsoleHelpers.windowBounds.MiddlePoint().x - 5);
        }


    }
}
