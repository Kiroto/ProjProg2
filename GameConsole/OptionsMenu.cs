using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace GameConsole
{
    class OptionsMenu
    {
        BoxBounds bounds;
        String[] options;
        int biggestOption;
        public int cursor = 0;

        public ConsoleColor backgroundColor = ConsoleColor.DarkGray;
        public ConsoleColor foregroundColor = ConsoleColor.White;
        public ConsoleColor selectedColor = ConsoleColor.White;
        public ConsoleColor selectedBackground = ConsoleColor.Blue;

        public OptionsMenu(String[] options, int positionX, int positionY)
        {
            this.options = options;
            setOptionsMaxLength();
            bounds = new BoxBounds(positionX, positionX + biggestOption, positionY, options.Length);
            Draw();
        }

        public void cursorUp()
        {
            cursor = --cursor < 0 ? options.Length - 1 : cursor;
        }

        public void cursorDown()
        {
            cursor = (cursor + 1) % options.Length;
        }

        void setOptionsMaxLength()
        {
            foreach(String opt in options)
            {
                biggestOption = opt.Length > biggestOption ? opt.Length : biggestOption;
            }
        }

        public void Draw()
        {
            for(int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(bounds.A.x, bounds.A.y + i);
                if (i == cursor)
                {
                    Console.BackgroundColor = selectedBackground;
                    Console.ForegroundColor = selectedColor;
                }
                else
                {
                    Console.BackgroundColor = backgroundColor;
                    Console.ForegroundColor = foregroundColor;
                }
                Console.Write(options[i].PadRight(bounds.Width()));
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(bounds.A.x, bounds.A.y + i);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("".PadRight(biggestOption));
            }
        }
    }
}
