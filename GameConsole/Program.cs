using System;
using Model;
using FlappyBird;
using Console_Snake;

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

            String[] options = { "Flappy Bird", "Snake","Options", "Exit" };

            BoxBounds optionsBounds = new BoxBounds(20, options.Length);
            ConsoleHelpers.centerBoxBound(optionsBounds);

            switch(ConsoleHelpers.optionsWindow(options, optionsBounds))
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Title = "Console Flappy Bird C#";
                    Console.CursorVisible = false;
                    Flappy flappy = new Flappy(75, 20);
                    flappy.Run();
                    Console.ReadKey();
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Black;q
                    Snake snake = new Snake();
                    while (true)
                    {
                        snake.WriteBoard();
                        snake.Input();
                        snake.Logic();
                    }
                    Console.ReadKey();


            }
        }
    }
}
