using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var wert1 = new wert();
            wert1.name = "zahl1";
            wert1.nummer = 2;
            var wert2 = new wert();
            var wert3 = new wert();
            var wert4 = new wert();

            var list = new List<wert>();
            list.Add(wert1);
            list.Add(wert2);
            list.Add(wert3);
            list.Add(wert4);

            DateTime dateTime = new DateTime();

           
            var filteredItems = list.Where(item => item.nummer > 1);

            var filterItems2 = from p in list where p.nummer == 2 select p.name;

            var filterItems2list = filteredItems.ToList();

           

            
        }
    }

    public class wert
    {
        public string name { get; set; }
        public int nummer { get; set; }
    }
}
