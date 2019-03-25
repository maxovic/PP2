using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task_2
{   [Serializable]
    public class Mark
    {
        [XmlArray(ElementName = "Attestation"), XmlArrayItem(ElementName = "Grades")]
        public int[] marks;
        public Mark()
        {
        }

        public string getletter(int n) 
        {
            if (n >= 95)
                return "A";
            else if(n >= 90)
            {
                return "-A";
            }
            else if(n >= 85)
            {
                return "+B";
            }
            else if(n >= 80)
            {
                return "B";
            }
            else if(n >= 75)
            {
                return "-B";
            }
            else if(n >= 70)
            {
                return "+C";
            }
            else if(n >= 65)
            {
                return "C";
            }
            else
            {
                return "-C";
            }
        }
        public string ToStringg(int nn)
        {
            string p = "Mark: " + getletter(nn)+ " Point: " + nn;
            return p;
        }
        public void ShowAttestation()
        {
            for(int i = 0; i < marks.Length; i++)
            {
                string p = ToStringg(marks[i]);
                Console.WriteLine(p);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DeSerialize();
        }

        public static void DeSerialize()
        {
            FileStream FS = new FileStream("mark.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer XS = new XmlSerializer(typeof(Mark));
            Mark M = XS.Deserialize(FS) as Mark;
            M.ShowAttestation();
            FS.Close();
        }

        public static void Serialize()
        {
            Mark m = new Mark();
            m.marks = new int[5] { 91, 97, 89, 84, 100 };
            FileStream FS = new FileStream("mark.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer XS = new XmlSerializer(typeof(Mark));
            XS.Serialize(FS,m);
            FS.Close();
        }
    }
}
