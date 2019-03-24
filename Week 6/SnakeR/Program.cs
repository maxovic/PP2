using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeR
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            game.Run();
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.ProcessKeyEvent(consoleKeyInfo);
            }
        }
    }
}
