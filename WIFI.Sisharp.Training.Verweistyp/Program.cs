using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Verweistyp
{
    public class Student
    {

        public string StudentName { get; set; }

    }

    public class Program
    {
        public static void ChangeReferenceType(Student std2)
        {
            std2.StudentName = "Steve";
        }

        public static void Main()
        {
            Student std1 = new Student();

            std1.StudentName = "Bill";

            ChangeReferenceType(std1);

            Console.WriteLine(std1.StudentName);

            Console.ReadLine();
        }
    }
}
