using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25
        }
    }


}
