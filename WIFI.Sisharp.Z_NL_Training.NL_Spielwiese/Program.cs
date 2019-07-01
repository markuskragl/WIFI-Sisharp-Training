using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.DateTimeTry
{
    class Program
    {
        static void Main(string[] args)
        {
            var Zeit = System.DateTime.Now;

            DateTime Date = new DateTime(year: 1990, month: 6, day: 3);

            
            Console.WriteLine(Date.DayOfWeek);
            Console.Read();
        }
    }
}
