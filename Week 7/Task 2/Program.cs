using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2
{
    class MyThread
    {
        public Thread theadField;

        public MyThread(string name)
        {
            
            theadField = new Thread(new ThreadStart(count));
            theadField.Name = name;
        }

        void count()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " выводит " + (i + 1));
            }
            Console.WriteLine(Thread.CurrentThread.Name + " завершился");
        } 
        public void startThread()
        {
            theadField.Start();
        }
        
    }
    class Program
    {   
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");
            MyThread t4 = new MyThread("Thread 4");
            t1.startThread();
            t2.startThread();
            t3.startThread();
            t4.startThread();

        }
    }
}
