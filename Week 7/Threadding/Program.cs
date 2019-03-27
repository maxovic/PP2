using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadding
{
    public class MyThread
    {
        public void ThreadNumbers()
        {
            Console.WriteLine("{0} поток использует метод ThreadNumbers", Thread.CurrentThread.Name);
            Console.WriteLine("Числа: ");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + ", ");
                Thread.Sleep(3000);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сколько использовать потоков (1 или 2)?");
            string number = Console.ReadLine();
            Thread myThread = Thread.CurrentThread;
            myThread.Name = "Первичный";

            Console.WriteLine("--> {0} главный поток", Thread.CurrentThread.Name);

            MyThread mt = new MyThread();
            switch (number)
            {
                case "1":
                    mt.ThreadNumbers();
                    break;
                case "2":
                    Thread BackgroundThread = new Thread(new ThreadStart(mt.ThreadNumbers));
                    BackgroundThread.Name = "Вторичный";
                    BackgroundThread.Start();
                    break;
                default:
                    Console.WriteLine("Using onethread");
                    goto case "1";
            }
            Console.WriteLine("TEST CASE;");
        }
    }
}
