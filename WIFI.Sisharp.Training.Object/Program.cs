using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Object
{
    class ObjectTest
    {
        public int i = 10;
    }

    class Program
    {
        static void Main()
        {
            object a;
            a = 1;   // an example of boxing
            Console.WriteLine(a);
            Console.WriteLine(a.GetType());
            Console.WriteLine(a.ToString());

            a = new ObjectTest();
            ObjectTest classRef;
            classRef = (ObjectTest)a;
            Console.WriteLine(classRef.i);
            Console.ReadLine();
        }
    }
    /* Output
        1
        System.Int32
        1
     * 10
    */
}
