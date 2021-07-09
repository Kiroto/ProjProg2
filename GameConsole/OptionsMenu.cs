using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Helpers;

namespace GameConsole
{
    class OptionsMenu
    {
        BoxBounds bounds;
        String[] options;
        public int cursor = 0;

        public ConsoleColor backgroundColor = ConsoleColor.DarkGray;
        public ConsoleColor foregroundColor = ConsoleColor.White;
        public ConsoleColor selectedBackground = ConsoleColor.DarkBlue;
        public ConsoleColor selectedColor = ConsoleColor.White;

        public OptionsMenu(String[] options, BoxBounds bb)
        {
            this.options = options;
            bounds = bb;
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

        public void Draw()
        {
            int width = bounds.Width();
            for(int i = 0; i < options.Length; i++)
            {
                BoxBounds lineBounds = new BoxBounds(width, 1);
                lineBounds.SetSource(bounds.A);
                lineBounds.Move(new Vector(0, i));
                ConsoleColor cuf;
                ConsoleColor cub;
                if (i == cursor)
                {
                    cub = selectedBackground;
                    cuf = selectedColor;
                }
                else
                {
                    cub = backgroundColor;
                    cuf = foregroundColor;
                }
                String line = options[i].PadSides(width);
                ConsoleHelpers.writeText(line, lineBounds, cuf, cub, ConsoleHelpers.Alignment.Center);
            }
        }

        public void Dispose()
        {
            ConsoleHelpers.clearBox(bounds);
        }
    }
}
