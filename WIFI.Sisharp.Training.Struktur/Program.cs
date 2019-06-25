using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Struktur
{
    // Declare and initialize struct objects.
    class TestCoords
    {
        static void Main()
        {
            // Initialize:   
            Coords coords1 = new Coords();
            Coords coords2 = new Coords(10, 10);

            // Display results:
            Console.Write("Coords 1: ");
            Console.WriteLine("x = {0}, y = {1}", coords1.x, coords1.y);

            Console.Write("Coords 2: ");
            Console.WriteLine("x = {0}, y = {1}", coords2.x, coords2.y);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    public struct Coords
    {
        public int x, y;

        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}
