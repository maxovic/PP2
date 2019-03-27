using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    public class UI:GameObject
    {
        public UI() : base()
        {
            
        }
        public UI(char sign) : base(sign)
        {
            Loadlevel(1);
        }
        public void showIntFace(object obj, string username)
        {
            Snake snake = (Snake)obj;
            Console.SetCursorPosition(22, 31);
            Console.Write(snake.body.Count);
            Console.SetCursorPosition(9, 31);
            Console.Write("your score: ");
            Console.SetCursorPosition(10, 30);
            Console.Write("your name: ");
            Console.SetCursorPosition(22, 30);
            Console.Write(username);
            Console.SetCursorPosition(6, 38);
            Console.Write("press R to restart the game");
            
        }
        private void Loadlevel(int level)
        {
            string name = string.Format(@"C:\git\PP2\Snake\Snake\Levels\level{0}.txt", level);
            using (StreamReader SR = new StreamReader(name))
            {
                int c = 0;
                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '*')
                        {
                            body.Add(new Point(i, c));
                        }
                    }
                    c++;
                }
            }
        }
    }
}
