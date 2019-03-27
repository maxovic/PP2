using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public class MyTheard
    {
        public void ThreadNumbers()
        {
            // Информация о потоке
            Console.WriteLine("{0} поток использует метод ThreadNumbers", Thread.CurrentThread.Name);
            // Выводим числа
            Console.Write("Числа: ");
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                Thread.Sleep(1000 * rand.Next(5));
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyTheard mt = new MyTheard();

            // Создаем 10 потоков
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(mt.ThreadNumbers));
                threads[i].Name = string.Format("Работает поток: #{0}", i);
            }

            // Запускаем все потоки
            foreach (Thread t in threads)
                t.Start();
        }
    }
}
