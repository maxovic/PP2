using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace chernovik
{

    [Serializable]
    class CNumbers
    {
        public int[] real = new int[5] { 4, 2, 6, 7, 1 };
        public string[] img1 = new string[5] { "+i", "+i", "+i", "+i", "+i" };
        public int[] img2 = new int[5] { 1, 6, 8, 3, 4 };
        public CNumbers()
        {
            priNt();
        }
        public void priNt()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(real[i] + img1[i] + img2[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

           
        }


        static void F2()
        {
            FileStream FS = new FileStream("seria.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer XMS = new XmlSerializer(typeof(CNumbers));
            CNumbers Cn = XMS.Deserialize(FS) as CNumbers;
            Cn.priNt();


            FS.Close();
        }


        static void F1()
        {
            CNumbers cn = new CNumbers();
            XmlSerializer XS = new XmlSerializer(typeof(CNumbers));

            FileStream FS = new FileStream("seria.xml", FileMode.Create, FileAccess.Write);
            XS.Serialize(FS, cn);
            FS.Close();

        }
    }
}
