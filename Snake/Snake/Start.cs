using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Start
    {
        static void user(int view, ConsoleColor color)
        {
            
            string link = string.Format(@"C:\git\PP2\Week 6\Snake\levels\username{0}.txt", view);
            FileStream FS = new FileStream(link, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);
            string line = SR.ReadToEnd();
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            FS.Close();
            SR.Close();
        }
        static void start()
        {
            ConsoleColor color = ConsoleColor.Cyan;
            user(1,color);
            for (double i = 0; i < 999999999; i++)
            {

            }
            Console.Clear();
            color = ConsoleColor.Green;
            user(2,color);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();
            color = ConsoleColor.Yellow;
            user(3,color);
            for (double i = 0; i < 199999999; i++)
            {

            }
            Console.Clear();
            color = ConsoleColor.Red;
            user(4,color);
            for (double i = 0; i < 199999999; i++)
            {

            }
            Console.Clear();
            color = ConsoleColor.White;
            user(5,color);
            for (double i = 0; i < 199999999; i++)
            {

            }
            Console.Clear();
        }
        public Start()
        {
            start();
        }
    }
}
