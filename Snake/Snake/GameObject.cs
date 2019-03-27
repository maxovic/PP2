using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class GameObject
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public GameObject() { }
        public GameObject(char sign)
        {
            this.sign = sign;
        }
        public GameObject(ConsoleColor color, char sign)
        {
            this.color = color;
            this.sign = sign;
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }
    }
}
