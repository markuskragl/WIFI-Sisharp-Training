using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.UniqueIdentifier
{
    class Program
    {
        static void Main()
        {
            Random probe = new Random();

            

            for (int i = 0; i < 5; i++)
            {
                int neu = probe.Next();

                Console.WriteLine(neu.ToString());
            }
            Console.Read();

        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
    }

}
