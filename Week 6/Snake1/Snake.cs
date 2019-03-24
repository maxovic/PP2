using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Snake : GameObject
    {
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {

        }
        public void Move(ConsoleKeyInfo keyInfo)
        {
            for(int i = body.Count-1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
                body[0].Y += 1;
            if (keyInfo.Key == ConsoleKey.UpArrow)
                body[0].Y -= 1;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                body[0].X -= 1;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                body[0].X += 1;
        }
    }
}
