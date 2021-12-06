using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using SkysDBDemoDatabas.Models;

namespace SkysDBDemoDatabas
{
    public class ApplicationDatabaseFirst
    {
        private readonly string _connectionString;

        public ApplicationDatabaseFirst(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Run()
        {
            var options = new DbContextOptionsBuilder<AuktionContext>();
            options.UseSqlServer( _connectionString );
            using (var context = new AuktionContext(options.Options))
            {
                while (true)
                {
                    Console.WriteLine("1. Create new user");
                    Console.WriteLine("2. List all users");
                    Console.WriteLine("0. Avsluta");

                    int sel = Convert.ToInt32(Console.ReadLine());
                    if (sel == 0)
                        break;
                    if (sel == 1)
                    {
                        var user = new User();
                        Console.WriteLine("Ange Användarnamn:");
                        user.Anvnamn = Console.ReadLine();
                        Console.WriteLine("Ange password:");
                        user.Password = Console.ReadLine();
                        Console.WriteLine("Ange namn:");
                        user.Namn = Console.ReadLine();
                        Console.WriteLine("Adress:");
                        user.Adress = Console.ReadLine();
                        Console.WriteLine("Postal:");
                        user.Postnummer = Console.ReadLine();
                        Console.WriteLine("Stad:");
                        user.Stad = Console.ReadLine();

                    }

                    //if (sel == 2)
                    //    ListAllUsers();

                }




                foreach (var user in context.Users.Where(r => r.Stad == "Sundsvall").OrderBy(r => r.Age))
                {
                    Console.WriteLine(user.Namn);
                }

            }
        }

    }
}