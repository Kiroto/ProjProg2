using System;
using Model;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            String welcomeText = "What Game would you like to play?";
            BoxBounds bb = new BoxBounds(welcomeText.Length, 1);
            ConsoleHelpers.centerBoxBoundH(bb);
            ConsoleHelpers.writeText(welcomeText, bb, bgColor: ConsoleColor.DarkYellow, al: ConsoleHelpers.Alignment.Center);

            String[] options = { "Tic-Tac-Toe", "Three And Two", "Options", "Exit" };

            BoxBounds optionsBounds = new BoxBounds(20, options.Length);
            ConsoleHelpers.centerBoxBound(optionsBounds);

            int selection = ConsoleHelpers.optionsWindow(options, optionsBounds);
        }
    }
}
