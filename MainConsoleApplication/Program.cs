using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstClassLibrary.Domain;
using SecondClassLibrary.Domain;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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

            Console.WriteLine("Adding entities");
            AddEntities();

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

        private static void AddEntities()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mainDatabase"].ConnectionString;
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        using (FirstModel firstModel = new FirstModel(connection, false))
                        {
                            firstModel.Database.UseTransaction(transaction);

                            Country country = new Country()
                            {
                                Name = "Mexico",
                                Code = "MX",
                                CreationDate = DateTime.Now,
                                Order = 1
                            };
                            State state = new State()
                            {
                                Name = "Tabasco",
                                Budget = new decimal(1000),
                                Country = country
                            };

                            firstModel.Countries.Add(country);
                            firstModel.States.Add(state);
                            firstModel.SaveChanges();
                        }

                        using (SecondModel secondModel = new SecondModel(connection, false))
                        {
                            secondModel.Database.UseTransaction(transaction);

                            Person person = new Person()
                            {
                                Name = "John Smith",
                                Married = false
                            };
                            Address address = new Address()
                            {
                                StreetName = "Zocalo",
                                StreetNumber = 99,
                                Person = person
                            };

                            secondModel.People.Add(person);
                            secondModel.Addresses.Add(address);
                            secondModel.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
