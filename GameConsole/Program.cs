using System;
using Model;
using FlappyBird;
using Console_Snake;
using System.Collections.Generic;

namespace GameConsole
{
    class Program
    {
        public static List<Score> scores = new List<Score>();

        static void Main(string[] args)
        {
            int state = 0;
            while (state != -1)
            {
                Console.Clear();
                Console.Title = "Select Your Game";

                String welcomeText = "What Game would you like to play?";
                BoxBounds textBounds = new BoxBounds(welcomeText.Length, 2);

                String flashText = "█▀▀ ▄▀█ █▀▄▀█ █▀▀█▄█ █▀█ █░▀░█ ██▄";
                BoxBounds flashBounds = new BoxBounds(flashText.Length / 2, 2);

                ConsoleHelpers.centerBoxBoundH(textBounds);
                ConsoleHelpers.centerBoxBoundH(flashBounds);
                flashBounds.Move(new Vector(0, 2));

                ConsoleHelpers.writeText(welcomeText, textBounds, bgColor: ConsoleColor.DarkBlue, al: ConsoleHelpers.Alignment.Center);
                ConsoleHelpers.writeText(flashText, flashBounds, bgColor: ConsoleColor.DarkBlue, al: ConsoleHelpers.Alignment.Center);


                String[] options = { "Flappy Bird", "Snake", "Tic-Tac-Toe", "Scores", "Exit" };

                BoxBounds optionsBounds = new BoxBounds(20, options.Length);
                ConsoleHelpers.centerBoxBound(optionsBounds);
                switch (ConsoleHelpers.optionsWindow(options, optionsBounds))
                {
                    case 0:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Title = "Console Flappy Bird C#";
                        Console.CursorVisible = false;
                        int birdState = 0;
                        while (birdState != -1)
                        {
                            Flappy flappy = new Flappy(75, 20);
                            flappy.Run();

                            int endGameOption = endGame(flappy.score, 0);
                            switch (endGameOption)
                            {
                                case 1:
                                    break;
                                case 2:
                                    birdState = -1;
                                    break;
                                case 3:
                                    birdState = -1;
                                    state = -1;
                                    break;
                            }
                        }
                        break;
                    case 1:
                        Console.Title = "Snek";

                        int snakeState = 0;
                        while (snakeState != -1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Snake snake = new Snake();
                            do
                            {
                                snake.WriteBoard();
                                snake.Input();
                            }
                            while (!snake.Logic());

                            Console.Clear();

                            int endGameOption = endGame(snake.GetScore(), 1);

                            switch (endGameOption)
                            {
                                case 1:
                                    break;
                                case 2:
                                    snakeState = -1;
                                    break;
                                case 3:
                                    snakeState = -1;
                                    state = -1;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.Title = "Tic-Tac-Toe";
                        int tttState = 0;
                        while (tttState != -1)
                        {
                            TicTacToeConsole tttc = new TicTacToeConsole();
                            tttc.playGame();
                            Console.Clear();

                            String prompt = "What do you want to do?";
                            BoxBounds promoptBounds = new BoxBounds(prompt.Length, 1);
                            ConsoleHelpers.centerBoxBoundH(promoptBounds);
                            promoptBounds.Move(new Vector(0, 2));
                            ConsoleHelpers.writeText(prompt, promoptBounds, bgColor: ConsoleColor.DarkYellow, al: ConsoleHelpers.Alignment.Center);
                            String[] promptOptions = { "Play Again", "Play Another Game", "Exit" };
                            BoxBounds promptOptionBounds = new BoxBounds(20, promptOptions.Length);
                            ConsoleHelpers.centerBoxBound(promptOptionBounds);
                            switch (ConsoleHelpers.optionsWindow(promptOptions, promptOptionBounds))
                            {
                                case 0:
                                    break;
                                case 1:
                                    tttState = -1;
                                    break;
                                case 2:
                                    tttState = -1;
                                    state = -1;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        showScores();
                        break;
                    case 4:
                        state = -1;
                        break;
                }
            }
        }

        private static void showScores()
        {
            Console.Clear();

            String title = "Flappy Bird Scores";
            BoxBounds titleBounds = new BoxBounds(30, 1);
            titleBounds.Move(new Vector(0, 2));
            ConsoleHelpers.writeText(title, titleBounds, bgColor: ConsoleColor.Blue, al: ConsoleHelpers.Alignment.Center);

            title = "Snake Scores";
            titleBounds = new BoxBounds(30, 1);
            titleBounds.Move(new Vector(34, 2));
            ConsoleHelpers.writeText(title, titleBounds, bgColor: ConsoleColor.Red, al: ConsoleHelpers.Alignment.Center);

            int snekScores = 0;
            int flappyScores = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                int lineHeight = 0;
                Score score = scores[i];
                ConsoleColor selectedColor = ConsoleColor.Black;

                if (score.gameID == 0)
                {
                    flappyScores++;
                    lineHeight = flappyScores;
                    selectedColor = ConsoleColor.DarkBlue;
                }
                else if (score.gameID == 1)
                {
                    snekScores++;
                    lineHeight = snekScores;
                    selectedColor = ConsoleColor.DarkRed;

                }
                String line = (score.score.ToString().PadLeft(5, '0')) + " - " + score.playerName;
                BoxBounds lineBounds = new BoxBounds(30, 1);
                lineBounds.Move(new Vector(score.gameID * 33 + 1, lineHeight + 4));
                ConsoleHelpers.writeText(line, lineBounds, bgColor: selectedColor, al: ConsoleHelpers.Alignment.Center);
            }
            Console.ReadKey();
        }

        // 1 for replay
        // 2 for another game
        // 3 for exit
        private static int endGame(int score, int gameId)
        {
            String prompt = "Your score was " + score + " What do you want to do?";
            BoxBounds promoptBounds = new BoxBounds(prompt.Length, 1);
            ConsoleHelpers.centerBoxBoundH(promoptBounds);
            promoptBounds.Move(new Vector(0, 2));
            ConsoleHelpers.writeText(prompt, promoptBounds, bgColor: ConsoleColor.DarkYellow, al: ConsoleHelpers.Alignment.Center);
            String[] promptOptions = { "Save Score", "Play Again", "Play Another Game", "Exit" };
            BoxBounds promptOptionBounds = new BoxBounds(20, promptOptions.Length);
            ConsoleHelpers.centerBoxBound(promptOptionBounds);
            int selectedOption = ConsoleHelpers.optionsWindow(promptOptions, promptOptionBounds);
            if (selectedOption == 0)
            {
                saveScore(score, gameId);
                selectedOption = 2;
            }
            return selectedOption;
        }

        private static void saveScore(int score, int gameId)
        {
            Console.Clear();

            String prompt = "What is your name?";
            BoxBounds promoptBounds = new BoxBounds(prompt.Length, 1);
            ConsoleHelpers.centerBoxBoundH(promoptBounds);
            promoptBounds.Move(new Vector(0, 2));

            Console.SetCursorPosition(5, 10);
            Console.Write("Name: ");
            string userName = Console.ReadLine();

            scores.Add(new Score(gameId, userName, score));
        }
    }
}
