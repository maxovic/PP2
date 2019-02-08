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
            StreamReader SR = new StreamReader(FS);
            string[] numbs = SR.ReadLine().Split(' ');
            List<int> list = new List<int>();
            foreach(var c in numbs)
            {
                int x = int.Parse(c);
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
            StreamWriter SW = new StreamWriter(FSS);
            for(int i = 0; i < list.Count; i++)
            {
                SW.Write(list[i] + " ");
            }
            SR.Close();
            SW.Close();
        }
    }
}
