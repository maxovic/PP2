using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake:GameObject
    {
        int dx = 0;
        int dy = 0;
        public int DX
        {
            get
            {
                return dx;
            }
            set
            {
                if (body.Count == 1 || dx + value != 0)
                    dx = value;
            }
        }
        public int DY
        {
            get
            {
                return dy;
            }
            set
            {
                if (body.Count == 1 || dy + value != 0)
                    dy = value;
            }
        }
        public Snake() : base() { }
        public Snake(ConsoleColor color, char sign) : base(color, sign)
        {
            body.Add(new Point(20, 20));
        }
        public void Move()
        {
            Clear();
            for(int i = body.Count-1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0].X += DX;
            body[0].Y += DY;
        }
        public bool IsIntersected(List<Point> points)
        {
            bool res = false;
            foreach (Point p in points)
            {
                if (body[0].X == p.X && body[0].Y == p.Y)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        public void Eat(List<Point> food)
        {
            body.Add(new Point(food[0].X, food[0].Y));
        }
    }
}
