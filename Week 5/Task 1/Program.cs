using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task_1
{
    [Serializable]
    class CNumbers
    {
        public int[] real = new int[5] { 4, 2, 6, 7, 1 };
        public string[] img1 = new string[5] { "+i", "+i", "+i", "+i", "+i" };
        public int[] img2 = new int[5] { 1, 6, 8, 3, 4 };


        public CNumbers()
        {
            Print();
        }

        public void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(real[i] + img1[i] + img2[i]);
            }
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
                Serialize();
                DeSerialize();
        }
        static void DeSerialize()
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(@"C:/git/PP2/Week 5/Task 1/student.bin", FileMode.Open, FileAccess.Read);
                CNumbers cN = binaryFormatter.Deserialize(fileStream) as CNumbers;
                fileStream.Close();
            }

        static void Serialize()
            {
                BinaryFormatter BF = new BinaryFormatter();
                FileStream FS = new FileStream(@"C:/git/PP2/Week 5/Task 1/student.bin", FileMode.Create, FileAccess.Write);
                CNumbers CN = new CNumbers();
                BF.Serialize(FS, CN);

                FS.Close();
            }
    }
}
