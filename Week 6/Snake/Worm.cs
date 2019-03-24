﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point { X = 20, Y = 20 });
        }

        public void Move(int dx, int dy)
        {
            Clear();
            for(int i = body.Count-1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += dx;
            body[0].Y += dy;
        }

        public bool CheckIntersection(Point point)
        {
            bool res = false;
            if (body[0].X == point.X && body[0].Y == point.Y)
                res = true;
            return res;
        }

        public bool IsCollisionWithWall(Wall wall)
        {
            foreach(Point p in wall.body)
            {
                if (p.X == body[0].X && p.Y == body[0].Y)
                    return true;
            }
            return false;
        }

        public bool IsCollisionWithItself()
        {
           for(int i = 1; i < body.Count; i++)
            {
                if(body[0].X == body[i].X && body[0].Y == body[0].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Eat(Point point)
        {
            body.Add(new Point { X = point.X, Y = point.Y });
        }
        
    }
}
