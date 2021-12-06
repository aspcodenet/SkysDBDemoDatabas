using System;
using Microsoft.Data.SqlClient;

namespace SkysDBDemoDatabas
{
//    public class Application
//    {
//        private readonly string _connectionString;

//        public Application(string connectionString)
//        {
//            _connectionString = connectionString;
//        }
//        public void Run()
//        {
//            //BLÄÄÄ
//            //  - magic strings
//            //  - sql inside C# application
//            //  - not OOP
//            // och vi har ju inte ens funderat över RELATIONER...

//            var dbConnection = new SqlConnection(_connectionString);
//            dbConnection.Open();
//            while (true)
//            {
//                Console.WriteLine("1. Create new user");
//                Console.WriteLine("2. List all users");
//                Console.WriteLine("0. Avsluta");

//                int sel = Convert.ToInt32(Console.ReadLine());
//                if (sel == 0)
//                    break;
//                if (sel == 1)
//                    CreateNewUser(dbConnection);
//                //if (sel == 2)
//                //    ListAllUsers();

//            }

//        }

//        private void CreateNewUser(SqlConnection dbConnection)
//        {
//            //Mata in
//            Console.WriteLine("Ange Användarnamn:");
//            var anvnamn = Console.ReadLine();
//            Console.WriteLine("Ange password:");
//            var password = Console.ReadLine();
//            Console.WriteLine("Ange namn:");
//            var namn = Console.ReadLine();
//            Console.WriteLine("Adress:");
//            var adress = Console.ReadLine();
//            Console.WriteLine("Postal:");
//            var postnummer = Console.ReadLine();
//            Console.WriteLine("Stad:");
//            var stad = Console.ReadLine();



//            var sql = @$"
//INSERT INTO [dbo].[User]
//           ([anvnamn]
//           ,[password]
//           ,[namn]
//           ,[adress]
//           ,[postnummer]
//           ,[stad], [age])
//     VALUES
//           (@anvnamn
//           ,@password
//           ,@namn
//           ,@address
//           ,@postnummer
//           ,@stad, @age)
//";
//            var command = new SqlCommand(sql, dbConnection);
//            command.Parameters.AddWithValue("@anvnamn", anvnamn);
//            command.Parameters.AddWithValue("@password", password);
//            command.Parameters.AddWithValue("@adress", adress);
//            //bl BL ABLA

//            command.ExecuteNonQuery();
//        }

//    }
}