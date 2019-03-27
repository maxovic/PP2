using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    public class GameState
    {
        public int level = 2;
        static int speed = 200;
        public bool alive = true;
        Timer timer = new Timer(speed);
        public string username;
        public Snake snake = new Snake(ConsoleColor.DarkGreen, 'O');
        public Food food = new Food(ConsoleColor.Yellow, 'x');
        public Wall wall = new Wall(ConsoleColor.Magenta, '#');
        public UI ui = new UI('*');

        public void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            snake.Clear();
            snake.Move();
            snake.Draw();
            ui.showIntFace(snake, username);
            CheckCollision();
            if (snake.body.Count % 5 == 0)
            {
                timer.Enabled = !timer.Enabled;
                NextLevel(level);
                level++;
            }
            
        }
        public void Restart()
        {
            snake.body.Clear();
            snake.body.Add(new Point(20, 20));
            snake.DX = 0;
            snake.DY = 0;
        }
        public void Run()
        {
            
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            food.GenerateFood(snake.body, wall.body, ui.body);
            wall.Draw();
            food.Draw();
            ui.showIntFace(snake, username);
            
            


        }
        public void Stop()
        {
            timer.Stop();
            Console.Clear();
        }
        public GameState(string username)
        {
            this.username = username;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public GameState() { }

        public void ProcessKeyEvent(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    snake.DX = 0;
                    snake.DY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    snake.DX = 0;
                    snake.DY = 1;
                    break;
                case ConsoleKey.RightArrow:
                    snake.DX = 1;
                    snake.DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    snake.DX = -1;
                    snake.DY = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;

            }
        }
        private void CheckCollision()
        {
            if (snake.IsIntersected(wall.body))
            {
                Stop();
                timer.Enabled = false;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("R to restart");
                Console.SetCursorPosition(10, 21);
                Console.Write("Q to quit");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.R:
                        Console.Clear();
                        timer.Enabled = true;
                        food.GenerateFood(snake.body, wall.body, ui.body);
                        wall.Draw();
                        food.Draw();
                        ui.showIntFace(snake, username);
                        Restart();
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.SetCursorPosition(13, 17);
                        Console.Write("Thanks for playing");
                        alive = false;
                        break;
                }
            }
            else if (snake.IsIntersected(food.body))
            {
                snake.Eat(food.body);
                food.GenerateFood(snake.body, wall.body, ui.body);
                food.Draw();
                speed -= 200;
                timer.Stop();
                timer.Interval = speed;
                timer.Start();
            }
        }
        void NextLevel(int level)
        {
            wall.body.Clear();
            Console.Clear();
            wall.Loadlevel(level);
            timer.Enabled = !timer.Enabled;
            wall.Draw();
            food.Draw();
            Restart();
        }
    }
}
