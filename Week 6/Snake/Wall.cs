using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Wall : GameObject
    {
        public Wall(char sign) : base(sign)
        {
            LevelLoad(1);
        }

        public void LevelLoad(int LEVEL)
        {
            string name = string.Format(@"C:\git\PP2\Week 6\Snake\levels\Level{0}.txt", LEVEL);
            using (StreamReader SR = new StreamReader(name))
            {
                int r = 0;
                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '#')
                            body.Add(new Point
                            {
                                X = i,
                                Y = r

                            });
                    }
                    r++;
                }
            }
        }
    }
}
