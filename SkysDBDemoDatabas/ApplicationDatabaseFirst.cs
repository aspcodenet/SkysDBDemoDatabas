using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
                    Console.WriteLine("3. Update");
                    Console.WriteLine("0. Avsluta");
                    Console.WriteLine("4. Login");


                    int sel = Convert.ToInt32(Console.ReadLine());
                    if (sel == 0)
                        break;
                    if (sel == 4)
                    {
                        var idToUpdate = 2;
                        var user = context.Users.First(e => e.Id == idToUpdate);
                        user.Inloggnings.Add(new Inloggning
                        {
                            Datumutc = DateTime.UtcNow,
                            Ipadress = "444.222.111.22"
                        });
                        context.SaveChanges(); //insert 
                    }

                    if (sel == 3)
                    {
                        var idToUpdate = 2;
                        var user = context.Users.First(e => e.Id == idToUpdate);
                        user.Adress = "Tempgatan 123";
                        user.Namn = "Stefan Holmberg2";
                        context.SaveChanges(); //update user set adress='', a
                    }
                    if (sel == 2)
                    {
                        // SELECT * FROM Users INNER JOIN INLOGGNING
                        foreach (var user in context.Users
                                     .Include(e=>e.Inloggnings)) 
                        {
                            Console.WriteLine($"{user.Namn}");
                            foreach (var inlogg in user.Inloggnings) // SELECT * FORM INLOGG WHERE USerid=user.Id
                            {
                                Console.WriteLine($"{inlogg.Datumutc}");
                            }

                        }
                    }
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
                        user.Postnummer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Stad:");
                        user.Stad = Console.ReadLine();

                        var inloggning = new Inloggning();
                        inloggning.Datumutc = DateTime.UtcNow;
                        inloggning.Ipadress = "111.111.11.11";

                        user.Inloggnings.Add(inloggning);
                        context.Users.Add(user);
                        context.SaveChanges();

                    }

                    //if (sel == 2)
                    //    ListAllUsers();

                }


            }
        }

    }
}