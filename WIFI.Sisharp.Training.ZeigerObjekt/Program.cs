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
            var Methoden = new Methoden();

            Eigenschaft Eigenschaft = new Eigenschaft();

            Eigenschaft.CreateText = "Hallo Welt";

            System.Console.WriteLine(Eigenschaft.CreateText);

            Methoden.WriteToConsole(Eigenschaft.CreateText);

            System.Console.Read();

        }


    }
}
