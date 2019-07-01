using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.ReflectionTry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using GetType to obtain type information:  
            var i = 42.0;
            Type type = i.GetType();
            System.Console.WriteLine(type);

            

            // Using Reflection to get information of an Assembly:  
            System.Reflection.Assembly info = typeof(System.Int32).Assembly;
            System.Console.WriteLine(info);


            System.Reflection.Assembly assemblyName = typeof(System.Double).Assembly;

            Console.WriteLine(assemblyName + "\r");

            Console.WriteLine("12345 \n 678");

            Console.Read();
        }
    }
}
