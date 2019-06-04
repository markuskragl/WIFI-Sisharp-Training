using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIFI.Sisharp.Training.Schnittstellen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is ODD");
            IFive obj1 = new ODDEVEN();
            obj1.ONE();
            obj1.THREE();
            obj1.FIVE();
            Console.WriteLine("\n\nThis is EVEN");
            IEVEN obj2 = new ODDEVEN();
            obj2.TWO();
            obj2.FOUR();
            Console.ReadLine();
        }
    }
}

