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
        static void user(int view)
        {
            string link = string.Format(@"C:\git\PP2\Week 6\Snake\levels\username{0}.txt", view);
            FileStream FS = new FileStream(link, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);
            string line = SR.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            FS.Close();
            SR.Close();
        }
        static void start()
        {
            user(1);
            for (double i = 0; i < 999999999; i++)
            {

            }
            Console.Clear();
            user(2);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();
            user(3);
            for (double i = 0; i < 199999999; i++)
            {

            }
            Console.Clear();
            user(4);
            for (double i = 0; i < 199999999; i++)
            {

            }
            Console.Clear();
            user(5);
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
