using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    public class Wall:GameObject
    {
        public Wall() : base() { }
        public Wall(ConsoleColor color, char sign) : base(color, sign)
        {
            Loadlevel(1);
        }
        public void Loadlevel(int level)
        {
            string name = string.Format(@"C:\git\PP2\Snake\Snake\Levels\level{0}.txt", level);
            using (StreamReader SR = new StreamReader(name))
            {
                int c = 0;
                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    for(int i = 0; i < line.Length; i++)
                    {
                        if(line[i] == '#')
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
