using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace SnakeR
{
    public class GameState
    {
        Timer timer = new Timer(1000);

        public Snake snake = new Snake('O');
        public Food food = new Food('x');
        public Wall wall = new Wall('#');
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void Run()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            food.GenerateLocation(snake.body, wall.body);
            wall.Draw();
            food.Draw();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            snake.Clear();
            snake.Move();
            snake.Draw();
        }

        public void Stop()
        {
            timer.Stop();
            Console.Clear();
        }
        public void ProcessKeyEvent(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    snake.Dx = 0;
                    snake.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    snake.Dx = 0;
                    snake.Dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                    snake.Dx = 1;
                    snake.Dy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    snake.Dx = -1;
                    snake.Dy = 0;
                    break;
            }
        }
    }
}
