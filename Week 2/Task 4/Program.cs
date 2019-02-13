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
            string path = @"C:/git/PP2/Week 2/path/info.txt";
            string path1 = @"C:/git/PP2/Week 2/path1/info.txt";
            FileStream FS = new FileStream(path, FileMode.Create, FileAccess.Write); // creating a new file;
            FS.Close(); // Closing the FileStream in order to give control to other functions
            File.Copy(path, path1, true); //Copies a file from path1 to path2
            File.Delete(path); // Deletes a file from path

        }

    }
}
