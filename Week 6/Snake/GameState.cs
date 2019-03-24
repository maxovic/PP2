using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameState
    {
        public string username;
        public Worm worm = new Worm('O');
        Food food = new Food('x');
        Wall wall = new Wall('#');

        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }

        public void LoginForm()
        {
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("TYPE YOUR NAME: ");
            Console.SetCursorPosition(15, 12);
            username = Console.ReadLine();
            Console.Clear();
        }
        public void ShowUserName()
        {
            Console.SetCursorPosition(15, 31);
            Console.WriteLine("User: " + username);
            Console.SetCursorPosition(15, 35);
            Console.WriteLine("Your score: " + worm.body.Count);
        }

        public void CheckCollision()
        {
            if (worm.CheckIntersection(food.body[0]))
            {
                worm.Eat(food.body[0]);
                food.Generate();
            }
        }
        public bool CheckCollisionWithWall()
        {
            if (worm.IsCollisionWithWall(wall))
            {
                return true;
            }
            return false;
        }
        public bool CheckCollisionWithItself()
        {
            if (worm.IsCollisionWithItself())
            {
                return true;
            }
            return false;
        }
        public void ProcessedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Move(1, 0);
                    break;

            }
            CheckCollision();
        }

        public void Draw()
        {
            
                ShowUserName();
                worm.Draw();
                food.Draw();
                wall.Draw();
            
        }
    }
}
