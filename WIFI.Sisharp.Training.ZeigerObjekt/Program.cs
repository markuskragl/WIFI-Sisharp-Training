using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.ZeigerObjekt
{
    class Program
    {
        static void Main()
        {
            //this 
            Console.WriteLine("Zeiger auf das aktuelle Objekt");
            var Methoden = new Methoden();

            Eigenschaft Eigenschaft = new Eigenschaft();

            Eigenschaft.CreateText = "Hallo Welt";

            System.Console.WriteLine(Eigenschaft.CreateText);

            Methoden.WriteToConsole(Eigenschaft.CreateText);


            //base
            Console.WriteLine("Aufrufen der Infor der aktuellen Basisklasse");
            Employee E = new Employee();
            E.GetInfo();

            System.Console.Read();

        }
    }

    public class Person
    {
        protected string ssn = "444-55-6666";
        protected string name = "John L. Malgraine";

        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("SSN: {0}", ssn);
        }
    }
    class Employee : Person
    {
        public string id = "ABC567EFG";
        public override void GetInfo()
        {
            // Calling the base class GetInfo method:
            base.GetInfo();
            Console.WriteLine("Employee ID: {0}", id);
            System.Console.Read();
        }
    }
}
