using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BoxBounds
    {
        public Point A;
        public Point B;

        public BoxBounds(int minX, int maxX, int minY, int maxY)
        {
            A = new Point(minX, minY);
            B = new Point(maxX, maxY);
        }

        public Point MiddlePoint()
        {
            return new Point(A.x + Width() / 2, A.y + Height() / 2);
        }

        public int Width()
        {
            return B.x - A.x;
        }

        public int Height()
        {
            return B.y - A.y;
        }
    }
}
