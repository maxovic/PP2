using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter tw = new StreamWriter(@"C:/git/PP2/Week 2/path/info.txt");
            string path1 = @"C:/git/PP2/Week 2/path/info.txt";
            string path2 = @"C:/git/PP2/Week 2/path1/info.txt";
            try
            {
                File.Copy(path1, path2);
            }
            catch (Exception)
            {
                File.Delete(path2);
                File.Copy(path1, path2);
            }
            tw.Close();
            File.Delete(path1);
            Console.WriteLine("The file was created, moved and deleted from dir 'path' successfully");
        }
    }
}
