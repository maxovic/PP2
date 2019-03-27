using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food:GameObject
    {
        public Food() : base() { }
        public Food(ConsoleColor color, char sign) : base(color, sign)
        {
            
        }
        public void GenerateFood(List<Point> sBody, List<Point> wBody, List<Point> uBody)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point(random.Next(0, 39), random.Next(0, 39));
            while (!IsGoodPoint(p, sBody) || !IsGoodPoint(p, wBody) || !IsGoodPoint(p, uBody))
            {
                p = new Point(random.Next(0, 39), random.Next(0, 39));
            }
            body.Add(p);

        }
        bool IsGoodPoint(Point p, List<Point> points)
        {
            bool res = true;

            foreach (Point t in points)
            {
                if (p.X == t.X && p.Y == t.Y)
                {
                    res = false;
                    break;
                }
            }

            return res;
        }
    }
}
