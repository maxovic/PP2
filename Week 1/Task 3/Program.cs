using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {   
        static void method(string a, string b)
        {
            int n = int.Parse(a); // int.Parsing(Converting to int) the given string 'a' to int;
            string[] arr = b.Split(' '); // Separating the string 'b';
            int[] array = new int[n]; // new array;
            for(int i = 0; i < n; i++)
            {
                int x = int.Parse(arr[i]);
                array[i] = x; // inserting digits from string[] arr to int[] array;

            }
            List<int> list = new List<int>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    list.Add(array[i]); // adding every element of int[] array twice in list
                }
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string s = Console.ReadLine();
            method(n, s);
        }
    }
}
