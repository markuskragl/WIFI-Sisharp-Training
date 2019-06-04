using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Arrays
{
    public class Program
    {
        public static void Main()
        {
            IList myArryList = new ArrayList()
            {
                1,
                "Two",
                3,
                4.5F
            };

            Console.WriteLine("Using for loop");

            foreach (var val in myArryList)
                Console.WriteLine(val);

            Console.WriteLine("Using foreach loop");

            for (int i = 0; i < myArryList.Count; i++)
                Console.WriteLine(myArryList[i]);
            Console.ReadLine();

            string[] weekDays1 = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            foreach (var val in weekDays1)
                Console.WriteLine(val);
            Console.ReadLine();

            int[] array1 = new int[] { 1, 3, 5, 7, 9 };
            foreach (var val in array1)
                Console.WriteLine(val);
            Console.ReadLine();

            void DisplayArray(string[] arr) => Console.WriteLine(string.Join(" ", arr));

            // Change the array by reversing its elements.
            void ChangeArray(string[] arr) => Array.Reverse(arr);

            void ChangeArrayElements(string[] arr)
            {
                // Change the value of the first three array elements. 
                arr[0] = "Mon";
                arr[1] = "Wed";
                arr[2] = "Fri";
            }

            // Declare and initialize an array.
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            // Display the array elements.
            DisplayArray(weekDays);
            Console.WriteLine();

            // Reverse the array.
            ChangeArray(weekDays);
            // Display the array again to verify that it stays reversed.
            Console.WriteLine("Array weekDays after the call to ChangeArray:");
            DisplayArray(weekDays);
            Console.WriteLine();

            // Assign new values to individual array elements.
            ChangeArrayElements(weekDays);
            // Display the array again to verify that it has changed.
            Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
            DisplayArray(weekDays);
            Console.ReadLine();
        }
    }
}