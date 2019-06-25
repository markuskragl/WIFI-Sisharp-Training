using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Anweisung
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Binärentscheidung");
            bool flagCheck = true;
            if (flagCheck)
            {
                Console.WriteLine("The flag is set to true.");
            }
            else
            {
                Console.WriteLine("The flag is set to false.");
            }
            Console.WriteLine();

            Console.WriteLine("Fallentscheidung");
            int caseSwitch = 1;
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.WriteLine();

            Console.WriteLine("Zählschleife");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.WriteLine("Abweiseschleife");
            int n = 1;
            while (n < 6)
            {
                Console.WriteLine("Current value of n is {0}", n);
                n++;
            }
            Console.WriteLine();

            Console.WriteLine("Durchlaufeschleife");
            int x = 0;
            do
            {
                Console.WriteLine(x);
                x++;
            }
            while (x < 5);
            Console.WriteLine();

            Console.WriteLine("Zuweiseschleife");
            int[] numbers = new int[] { 3, 14, 15, 92, 6 };
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();


            Console.Read();

        }
    }
}
