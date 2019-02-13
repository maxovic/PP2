using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        public static void space(int a)
        {
            for (int i = 0; i < a; i++)
            {
                Console.Write("   ");
            }
        }
        public static void folder(DirectoryInfo All, int a)
        {
            foreach (FileSystemInfo FSI in All.GetFileSystemInfos())
            {
                if (FSI.GetType() == typeof(DirectoryInfo))
                {
                    space(a);
                    Console.WriteLine(FSI.Name);
                    DirectoryInfo DI = FSI as DirectoryInfo;
                    folder(DI, a + 2);
                }
                else
                {
                    space(a);
                    Console.WriteLine(FSI.Name);
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo All = new DirectoryInfo(@"D:\KBTU LIFE");
            folder(All, 0);
        }
    }
}
