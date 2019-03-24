using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Game
    {
        public Snake snake;

        public bool Alive;

        List<GameObject> g_objects;

        public Game()
        {
            Alive = true;
            snake = new Snake(20, 20, 'O', ConsoleColor.Green);
            g_objects = new List<GameObject>();
            g_objects.Add(snake);
            Console.CursorVisible = false;
        }
        public void Start()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            while(keyInfo.Key != ConsoleKey.Escape && Alive)
            {
                snake.Move(keyInfo);
                Draw();
            }
        }

        public void Draw()
        {
            Console.Clear();
            foreach(GameObject g in g_objects)
            {
                g.Draw();
            }
        }
    }
}
