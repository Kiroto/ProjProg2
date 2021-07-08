using System;
using Model;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            String welcomeText = "What Game would you like to play?";
            BoxBounds textBounds = new BoxBounds(welcomeText.Length, 1);
            ConsoleHelpers.centerBoxBoundH(textBounds);
            ConsoleHelpers.writeText(welcomeText, textBounds, bgColor: ConsoleColor.DarkYellow, al: ConsoleHelpers.Alignment.Center);

            String[] options = { "Tic-Tac-Toe", "Worm", "Three And Two", "Options", "Exit" };

            BoxBounds optionsBounds = new BoxBounds(20, options.Length);
            ConsoleHelpers.centerBoxBound(optionsBounds);

            switch(ConsoleHelpers.optionsWindow(options, optionsBounds))
            {
                case 0:
                    TicTacToeConsole.main();
                    break;
            }
        }
    }
}
