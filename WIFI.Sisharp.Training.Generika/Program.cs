using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Generika
{
    public class Program
    {
        public static void Main()
        {
            var intGenericClass = new MyGenericClass<string>();

            intGenericClass.genericMethod("Hallo Welt");
        }
    }

    public class MyGenericClass<T>
    {
        public void genericMethod(T MeinWert)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), MeinWert);
            Console.ReadLine();
        }
    }
}
