using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS = new FileStream(@"C:/git/PP2/Week 2/input.txt", FileMode.Open, FileAccess.Read);
            // FileStream connects the file "input.txt" to its variable "FS";
            StreamReader SR = new StreamReader(FS);
            // StreamReader saves all content from FS(input.txt)
            string[] numbs = SR.ReadLine().Split(' '); // split function helps us to separate the whole string into substrings, then gives the substrings to array;
            List<int> list = new List<int>();
            foreach(var c in numbs)
            {
                int x = int.Parse(c); // int.Parse = Convert to int
                int ok = 1;
                for(int i = 2; i < x; i++)
                {
                    if(x%i == 0)
                    {
                        ok = 0;
                        break;
                    }
                }
                if(ok == 1 && x > 1)
                {
                    list.Add(x);
                }
            }
            FileStream FSS = new FileStream(@"C:/git/PP2/Week 2/output.txt", FileMode.Create, FileAccess.Write);
            // Failstream connects "FSS" to "output.txt"
            StreamWriter SW = new StreamWriter(FSS);
            //StreamWriter connects to FSS(output.txt)
            for (int i = 0; i < list.Count; i++)
            {
                SW.Write(list[i] + " ");
                Console.Write(list[i] + " ");
            }
            SR.Close();
            SW.Close();
        }
    }
}
