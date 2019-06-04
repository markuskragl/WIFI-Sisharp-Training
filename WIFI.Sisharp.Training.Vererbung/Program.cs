using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Vererbung
{
    public class A
    {
        public int wertA = 10;
        public int wertC = 100;


        //public class B : A
        //{
        //    public int GetValue()
        //    {
        //        return this.value;
        //    }
        //}
    }

    public class B : A
    {
        //public int GetValue()
        //{
        //    return this.wert;
        //}
        public int Eigenschaft {get; set;}
    }

    public class C : B
    {
        public int GetValue()
        {
            return this.wertA;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var c = new C();
            c.Eigenschaft = c.wertC;
            Console.WriteLine($"Gibt von der Initialisierung {c.ToString()} den Wert {c.GetValue()} zurück.");
            Console.WriteLine($"Gibt von der Initialisierung {c.ToString()} von Eigenschaft den Wert {c.Eigenschaft} zurück.");
            Console.ReadLine();
        }
    }
}
