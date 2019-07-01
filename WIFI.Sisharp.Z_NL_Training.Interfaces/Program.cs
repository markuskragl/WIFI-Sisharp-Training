using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {


        }
    }

    interface IEquatable<T>
    {
        bool Equals(T obj);
    }

    public class Car : IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {
            return this.Make == car.Make &&
                   this.Model == car.Model &&
                   this.Year == car.Year;
        }
    }

    interface ILeft
    {
        int P { get; }
    }
    interface IRight
    {
        int P();
    }

    class Middle : ILeft
    {
         int ILeft.P
        {
            get
            {
                return 0;
            }
        }

        public int P() { return 0; }
        
    }

    interface IDimensions
    {
        float getLength();
        float getWidth();
    }

    class Box : IDimensions
    {
        float lengthInches;
        float widthInches;

        Box(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }
        // Explicit interface member implementation: 
        float IDimensions.getLength()
        {
            return lengthInches;
        }
        // Explicit interface member implementation:
        float IDimensions.getWidth()
        {
            return widthInches;
        }

        static void Main()
        {
            // Declare a class instance box1:
            Box box1 = new Box(30.0f, 20.0f);

            // Declare an interface instance dimensions:
            IDimensions dimensions = box1;

            // The following commented lines would produce compilation 
            // errors because they try to access an explicitly implemented
            // interface member from a class instance:                   
            //System.Console.WriteLine("Length: {0}", box1.getLength());
            //System.Console.WriteLine("Width: {0}", box1.getWidth());

            // Print out the dimensions of the box by calling the methods 
            // from an instance of the interface:
            System.Console.WriteLine("Length: {0}", dimensions.getLength());
            System.Console.WriteLine("Width: {0}", dimensions.getWidth());
        }
    }
    /* Output:
        Length: 30
        Width: 20
    */
}
