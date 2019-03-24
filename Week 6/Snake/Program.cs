using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Snake
{
    class Program
    { 
        static void Main(string[] args)
        {
            bool alive = true;
            //Start start = new Start();
            GameState game = new GameState();
            game.LoginForm();
            while (alive)
            {       
                game.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.ProcessedKey(consoleKeyInfo);
                if (game.CheckCollisionWithWall())
                {
                    Console.Clear();
                    FileStream FS = new FileStream(@"C:\git\PP2\Week 6\Snake\levels\loser.txt", FileMode.Open, FileAccess.Read);
                    StreamReader SR = new StreamReader(FS);
                    string line = SR.ReadToEnd();
                    Console.WriteLine(line);
                    ConsoleKeyInfo CKI = Console.ReadKey();
                    if(CKI.Key == ConsoleKey.R)
                    {
                        Console.Clear();
                        game.worm.body[0].X = 20;
                        game.worm.body[0].Y = 20;
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        alive = false;

                    }
                }
                if (game.CheckCollisionWithItself())
                {
                    alive = false;
                }
            }
        }
    }
}
