using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstClassLibrary.Domain;
using SecondClassLibrary.Domain;

namespace MainConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecting countries");
            List<Country> countries = GetCountries();

            Console.WriteLine("Selecting people");
            List<Person> people = GetPeople();

            Console.WriteLine("Press intro key to continue...");
            Console.Read();
        }

        private static List<Country> GetCountries()
        {
            List<Country> result = null;

            using (var db = new FirstModel())
            {
                result = db.Countries.ToList();
            }

            return result;
        }

        private static List<Person> GetPeople()
        {
            List<Person> result = null;

            using(var db = new SecondModel())
            {
                result = db.People.ToList();
            }

            return result;
        }
    }
}
