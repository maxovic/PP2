using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine(); // As we can't directly insert integers, firstly, we need to read it as string;
            int n = int.Parse(s); // Function "Parse" allows us to convert string to int;
            string[,] arr = new string[n, n]; // Created 2D array;
            /* 
             00 01 02 03
             10 11 12 13
             20 21 22 23
             30 31 32 33
                
             Increase 'j' till j <= i and to those positions put "[*]";
             */
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    arr[i, j] = "[*]";
                }
            }

            // Showing elements in [i,j<=i]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            // Easier way to do that
            /* 
             for (int i = 1; i <= n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
            }
              */

        }
    }
}
