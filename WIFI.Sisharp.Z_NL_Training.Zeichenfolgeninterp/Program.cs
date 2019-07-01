using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Zeichenfolgeninterp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            // Both calls produce the same output that is similar to:
            // Hello, Mark! Today is Wednesday, it's 19:40 now.

            Console.ReadLine();
        }
    }
}
