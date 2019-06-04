using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.ZeigerObjekt
{
    public class Methoden
    {
        public void WriteToConsole(string Text)
        {
            System.Console.WriteLine("Aktuelles Objekt: {0} und über die Eigenschaft wird das Wort {1} erstellt", this, Text);
            System.Console.Read();
        }
    }
}
