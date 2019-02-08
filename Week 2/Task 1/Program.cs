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
            StreamReader SR = new StreamReader(FS);
            string line = SR.ReadToEnd();
            int cnt = 0;
            for (int i = 0; i < line.Length / 2; i++)
            {
                if (line[i] == line[line.Length - 1 - i])
                {
                    cnt++;
                }
            }
            FileStream FSS = new FileStream(@"C:\git\PP2\Week 2\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(FSS);
            if (cnt == line.Length / 2)
                SW.Write("Yes");
            else
                SW.Write("No");
            SR.Close();
            SW.Close();
        }
    }
}