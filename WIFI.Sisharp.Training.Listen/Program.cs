using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Training.Listen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> listOfUsers = new List<User>()
            {
                new User() { Name = "John Doe", Age = 42 },
                new User() { Name = "Jane Doe", Age = 34 },
                new User() { Name = "Joe Doe", Age = 8 },
            };

            for (int i = 0; i < listOfUsers.Count; i++)
            {
                Console.WriteLine(listOfUsers[i].Name + " is " + listOfUsers[i].Age + " years old");
            }
            Console.ReadKey();
        }
    }

    class User
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
