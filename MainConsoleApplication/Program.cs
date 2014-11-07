using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstClassLibrary.Domain;

namespace MainConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selecting countries");
            List<Country> countries = SelectCountries();

            Console.WriteLine("Press intro key to continue...");
            Console.Read();
        }

        private static List<Country> SelectCountries()
        {
            List<Country> result = null;

            using (var db = new FirstModel())
            {
                List<Country> countries = db.Countries.ToList();
            }

            return result;
        }
    }
}
