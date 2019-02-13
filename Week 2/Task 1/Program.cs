using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS = new FileStream(@"C:/git/PP2/Week 2/input.txt", FileMode.Open, FileAccess.Read);
            // FileStream connects the file "input.txt" to its variable "FS";
            StreamReader SR = new StreamReader(FS);
            // StreamReader saves all content from FS(input.txt)
            string line = SR.ReadToEnd(); // ReadToEnd, gives SR's content to string "line"
            int cnt = 0;
            for (int i = 0; i < line.Length / 2; i++)
            {
                if (line[i] == line[line.Length - 1 - i])
                {
                    cnt++;
                }
            }
            FileStream FSS = new FileStream(@"C:\git\PP2\Week 2\output.txt", FileMode.Create, FileAccess.Write);
            // Failstream connects "FSS" to "output.txt"
            StreamWriter SW = new StreamWriter(FSS);
            //StreamWriter connects to FSS(output.txt)
            if (cnt == line.Length / 2)
            {
                Console.WriteLine("Yes");
                SW.Write("Yes");
                //if string is poly, StreamWriter wrties "Yes" in output.txt;
            }
            else
            {
                Console.WriteLine("No");
                SW.Write("No");
                // otherwise, no;
            }
            SR.Close();
            SW.Close();
        }
    }
}