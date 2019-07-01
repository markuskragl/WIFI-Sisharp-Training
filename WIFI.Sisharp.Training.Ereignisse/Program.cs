using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Ereignisse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(AbbruchKommado);

            Console.WriteLine("Bitte drücken Sie Ctrl^C bzw. Strg^C ...");

            // auf Auslösung des Events warten
            Console.ReadKey();
        }

        private static void AbbruchKommado(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Event von Ctrl^C bzw. Strg^C erhalten!");

            // Konsole offen halten, sodass der User die Nachricht lesen kann
            Console.ReadKey();
        }
    }
}
