using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        int x;
        int y;

        //int Filter(int vx) 
        //{
          //  if (vx >= 40)
            //{
              //  vx = 0;
            //}
            //if (vx < 1)
            //{
              //  vx = 38;
            //}
            //return vx;
        //}

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

    }
}
