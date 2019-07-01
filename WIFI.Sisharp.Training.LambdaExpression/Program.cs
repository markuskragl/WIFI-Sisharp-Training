using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.LambdaExpression
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Square");
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25
            Console.WriteLine();

            Console.WriteLine("LINQ Square");
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
            // Output:
            // x => (x * x)
            Console.WriteLine();

            Console.WriteLine("Join Array via lambda expression");
            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25
            Console.WriteLine();


            Console.WriteLine("Anweisungslambdas");
            Action<string> greet = name => {string greeting = $"Hello {name}!"; Console.WriteLine(greeting);};
            greet("World");
            greet("nochwas");
            // Output:
            // Hello World!

            Console.Read();

        }
    }
}
