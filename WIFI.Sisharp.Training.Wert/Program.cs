using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Wert
{
    class TimePeriod
    {
        private double _seconds;

        public double Hours
        {
            get { return _seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    //throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 24.");
                    Console.WriteLine($"{nameof(value)} must be between 0 and 24.");
                Console.WriteLine($"{value} must be between 0 and 24.");

                _seconds = value * 3600;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TimePeriod t = new TimePeriod();
            // The property assignment causes the 'set' accessor to be called.
            t.Hours = 28;

            // Retrieving the property causes the 'get' accessor to be called.
            Console.WriteLine($"Time in hours: {t.Hours}");
            Console.ReadLine();
        }
    }
}
