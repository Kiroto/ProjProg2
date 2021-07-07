using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace GameConsole
{
    class ConsoleHelpers
    {
        public static BoxBounds windowBounds = new BoxBounds(0, Console.WindowWidth, 0, Console.WindowHeight);

        public static void centerComponentH(BoxBounds bb, int componentWidth)
        {
            Console.SetCursorPosition(bb.MiddlePoint().x - componentWidth/2, Console.CursorTop);
        }

        public static void centerComponentH(int componentWidth)
        {
            centerComponentH(windowBounds, componentWidth);
        }


    }
}
