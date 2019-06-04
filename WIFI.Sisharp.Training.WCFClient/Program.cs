using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.WCFClient
{
    class Program
    {
        static void Main()
        {
            localhost.MathServiceClient mc = new localhost.MathServiceClient();



            int a = 5;
            int b = 6;



            var Land= mc.GetCountries("AT")  ;


                        Console.Write(mc.Calc(a, b).ToString());
            Console.ReadLine();

        }

    }

    public class CountryManager
    {

        private static localhost.Country[] _Countries = null;

        /// <summary>
        /// Gets the supported countries.
        /// </summary>
        /// <remarks>The countries are cached.</remarks>
        public localhost.Country[] Countries
        {
            get
            {

                return CountryManager._Countries;
            }
        }

    }



    /// <summary>
    /// Provides a list of lottery countries.
    /// </summary>
    public class Countries : System.Collections.Generic.List<Country>
    {

    }

    /// <summary>
    /// Provides information about a country
    /// where the lottery game is supported.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or set the ISO code of the country.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the readable name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the highest lottery number in this country.
        /// </summary>
        public int MaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the count of numbers in a lottery bet.
        /// </summary>
        public int NumberCount { get; set; }

    }
}
