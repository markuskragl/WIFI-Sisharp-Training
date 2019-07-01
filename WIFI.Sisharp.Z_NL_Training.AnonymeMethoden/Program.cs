using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.AnonymeMethoden
{
    // Declare a delegate.
    delegate void Printer(string s);
    delegate void Del(string j);
    

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the delegate type using an anonymous method.
            Printer p = delegate (string j)
            {
                System.Console.WriteLine(j);
            };

            // Results from the anonymous delegate call.
            p("The delegate using the anonymous method is called.");

            // The delegate instantiation using a named method "DoWork".
            p = DoWork;

            // Results from the old style delegate call.
            p("The delegate using the named method is called.");

            var te = new Test();
            Del testDel = new Del(te.d);

            testDel("lskjfgaljkg");
          
        }

        // The method associated with the named delegate.
        static void DoWork(string k)
        {
            System.Console.WriteLine(k);
        }
    }

    public class Test
    {
        public  void d(string j)
        {
            Console.WriteLine(j);
        }

    }
}
