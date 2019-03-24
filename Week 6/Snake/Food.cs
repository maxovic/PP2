using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Food : GameObject
    {
        public Food(char sign) : base(sign)
        {
            Generate();
        }

        
        public void Generate()
        {
            Random random = new Random(DateTime.Now.Second);
            body.Clear();
            body.Add(new Point { X = random.Next(2,38), Y = random.Next(2,29) });
        }
    }
}
