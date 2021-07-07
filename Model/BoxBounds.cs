using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BoxBounds
    {
        public Vector A;
        public Vector B;

        public BoxBounds(int minX, int maxX, int minY, int maxY)
        {
            A = new Vector(minX, minY);
            B = new Vector(maxX, maxY);
        }

        public BoxBounds(int width, int height)
        {
            A = new Vector(0, 0);
            B = new Vector(width, height);
        }

        public Vector MiddlePoint()
        {
            return new Vector(A.x + Width() / 2, A.y + Height() / 2);
        }

        public int Width()
        {
            return B.x - A.x;
        }

        public int Height()
        {
            return B.y - A.y;
        }

        public void SetSource(Vector v)
        {
            int width = Width();
            int height = Height();
            A.x = v.x;
            A.y = v.y;
            B.x = A.x + width;
            B.y = A.y + height;
        }

        public void Move(Vector v)
        {
            A.x += v.x;
            A.y += v.y;
            B.x += v.x; 
            B.y += v.y;
        }
    }
}
