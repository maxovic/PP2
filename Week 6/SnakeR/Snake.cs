using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeR
{
    public class Snake : GameObject
    {
        public int Dx
        {
            get;
            set;
        }
        public int Dy
        {
            get;
            set;
        }
        public Snake() : base() { }
        public Snake(char sign) : base(sign)
        {
            body.Add(new Point(20, 20));
            Dx = Dy = 0;
        }
        public void Move()
        {
            Clear();
            for(int i = body.Count-1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0].X += Dx;
            body[0].Y += Dy;
        }
    }
}
