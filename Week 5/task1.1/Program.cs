using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace task1._1
{
    [Serializable]
    public class ComplexNumber
    {
        [XmlElement(ElementName = "Real Part")]
        public int a;
        [XmlElement(ElementName = "Imaginary Part")]
        public int b;
        
        public ComplexNumber() { }

        public void printCN()
        {
            Console.WriteLine(a + "+" + b + "i");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeSER();
        }
        static void SER()
        {
            ComplexNumber CN = new ComplexNumber();
            CN.a = 2;
            CN.b = 6;
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));
            FileStream FS = new FileStream("CN.xml", FileMode.Create, FileAccess.Write);
            XS.Serialize(FS, CN);

            FS.Close();
        }
        static void DeSER()
        {
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));
            FileStream FS = new FileStream("CN.xml", FileMode.Open, FileAccess.Read);
            ComplexNumber CN = XS.Deserialize(FS) as ComplexNumber;

            CN.printCN();

            FS.Close();

        }
    }
}
