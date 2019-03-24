using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class GameObject
    {
        public List<Point> body;
        public char sign;
        ConsoleColor color;
        public GameObject() { }
        public GameObject(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point>();
            body.Add(new Point {X = 20, Y = 20});
            this.sign = sign;
            this.color = color;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
    }
}
