using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeR
{
    public class Wall : GameObject
    {
        public Wall() : base() { }
        public Wall(char sign) : base(sign)
        {
            LoadLevel(1);
        }
        void LoadLevel(int level)
        {
            string name = string.Format(@"Levels/level{0}.txt", level);
            using (StreamReader streamReader = new StreamReader(name))
            {
                int r = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    for(int i = 0; i < line.Length; i++)
                    {
                        if(line[i] == '#')
                        {
                            body.Add(new Point(i, r));
                        }
                    }
                    r++;
                }
            }
        }
    }
}
