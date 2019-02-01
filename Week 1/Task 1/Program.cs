using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // Reading a line by converting it to INT using the function "Parse". n = length of array.
            string[] numb = Console.ReadLine().Split(' '); /* Next step, We need to read our N integers as string,
            then, the function Split helps us to seperate our digits.
            */
            List<int> list = new List<int>(); // Created a new list
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(numb[i]); // Numb's elements are still in String, thus I'm converting it into int.
                int ok = 1;
                for (int j = 2; j <= x / 2; j++) // Identifying the primes
                {
                    if (x % j == 0)
                    {
                        ok = 0;
                        break;
                    }
                }

                if (ok == 1 && x > 1) // if number is prime and greater than 1, add it into list
                    list.Add(x);
            }
            Console.WriteLine(list.Count); // list.count == length of list
            for (int i = 0; i < list.Count; i++)
                Console.Write(list[i] + " "); // Showing the prime numbers;
        }
    }
}
