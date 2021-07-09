using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Helpers;

namespace GameConsole
{
    class ConsoleHelpers
    {
        public static BoxBounds windowBounds = new BoxBounds(Console.WindowWidth, Console.WindowHeight);

        static readonly ConsoleKey OK = ConsoleKey.Enter;
        static readonly ConsoleKey UP = ConsoleKey.UpArrow;
        static readonly ConsoleKey DOWN = ConsoleKey.DownArrow;

        static ConsoleColor defaultForeground = ConsoleColor.White;
        static ConsoleColor defaultBackground = ConsoleColor.Black;

        public enum Alignment
        {
            Left,
            Center,
            Right
        }

        public static void centerBoxBound(BoxBounds bb, BoxBounds container)
        {
            centerBoxBoundH(bb, container);
            centerBoxBoundV(bb, container);
        }

        public static void centerBoxBound(BoxBounds bb)
        {
            centerBoxBound(bb, windowBounds);
        }

        public static void centerBoxBoundH(BoxBounds bb, BoxBounds container)
        {
            Vector mp = container.MiddlePoint();

            int boundsWidth = bb.Width();
            bb.A.x = mp.x - boundsWidth / 2;
            bb.B.x = bb.A.x + boundsWidth;
        }

        public static void centerBoxBoundV(BoxBounds bb, BoxBounds container)
        {
            Vector mp = container.MiddlePoint();

            int boundsHeight = bb.Height();
            bb.A.y = mp.y - boundsHeight / 2;
            bb.B.y = bb.A.y + boundsHeight;
        }

        public static void centerBoxBoundH(BoxBounds bb)
        {
            centerBoxBoundH(bb, windowBounds);
        }

        public static void centerBoxBoundV(BoxBounds bb)
        {
            centerBoxBoundV(bb, windowBounds);
        }

        public static void writeText(String text, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null, Alignment al = Alignment.Left)
        {
            writeText(text, windowBounds, fgColor, bgColor, al);
        }

        public static void writeText(String text, BoxBounds bb, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null, Alignment al = Alignment.Left)
        {
            Console.BackgroundColor = (bgColor != null ? bgColor.Value : defaultBackground);
            Console.ForegroundColor = (fgColor != null ? fgColor.Value : defaultForeground);

            int boxWidth = bb.Width();
            boxWidth = boxWidth > text.Length ? text.Length : boxWidth;

            List<String> lines = text.SplitChunks(boxWidth);
            Console.CursorTop = bb.A.y;

            for (int i = 0; i < lines.Count; i++)
            {
                switch (al)
                {
                    case Alignment.Right:
                        Console.SetCursorPosition(bb.B.x - text.Length, bb.A.y + i);
                        break;
                    case Alignment.Center:
                        Console.SetCursorPosition(bb.MiddlePoint().x - boxWidth / 2, bb.A.y + i);
                        break;
                    case Alignment.Left:
                        Console.SetCursorPosition(bb.A.x, bb.A.y + i);
                        break;
                }
                Console.Write(lines[i].PadRight(boxWidth));
            }

            Console.BackgroundColor = defaultBackground;
            Console.ForegroundColor = defaultForeground;
        }

        public static int optionsWindow(String[] options, BoxBounds bb)
        {
            OptionsMenu optionsMenu = new OptionsMenu(options, bb);
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
    
        public static void clearBox(BoxBounds bb)
        {
            for (int i = 0; i < bb.Height(); i++)
            {
                Console.SetCursorPosition(bb.A.x, bb.A.y + i);
                Console.BackgroundColor = defaultBackground;
                Console.ForegroundColor = defaultForeground;
                Console.Write("".PadRight(bb.Width()));
            }
           
        }
    }
}
