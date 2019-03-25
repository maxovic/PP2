using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace task_2._1
{
    public class Mark
    {
        int CurMark = 0;

        public int Filter(int n)
        {
            if (n > 100)
                return 100;
            else if (n < 0)
                return 0;
            else
                return n;
        }
        
        public int Grade
        {
            get
            {
                return CurMark;
            }
            set
            {
                CurMark = Filter(value);
            }
        }
        public Mark() { }
        public Mark(int Grade_)
        {
            Grade = Grade_;
        }

        public string getletter(int n)
        {
            if (n >= 95)
                return "A";
            else if (n >= 90)
            {
                return "-A";
            }
            else if (n >= 85)
            {
                return "+B";
            }
            else if (n >= 80)
            {
                return "B";
            }
            else if (n >= 75)
            {
                return "-B";
            }
            else if (n >= 70)
            {
                return "+C";
            }
            else if (n >= 65)
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
            string p = "Mark: " + getletter(nn) + " Point: " + nn;
            return p;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            DeSER();
        } 

        static void DeSER()
        {
            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));
            FileStream FS = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read);
            List<Mark> MarksAfterSER = XS.Deserialize(FS) as List<Mark>;

            foreach(Mark M in MarksAfterSER)
            {
                string p = M.ToStringg(M.Grade);
                Console.WriteLine(p);
            }
            FS.Close();
        }

        static void SER()
        {
            List<Mark> marks = new List<Mark>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                marks.Add(new Mark(random.Next(50, 100)));
            }
            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));
            FileStream FS = new FileStream("Marks.xml", FileMode.Create, FileAccess.Write);
            XS.Serialize(FS, marks);

            FS.Close();
        }
    }
}
