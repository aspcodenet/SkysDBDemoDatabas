using System;
using Microsoft.Extensions.Configuration;

namespace SkysDBDemoDatabas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Config
            //string connectionString =
            //    "Server=localhost;Database=Auktion;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true";

            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            
            //Connect med connectionString

            var application = new Application();
            application.Run();
        }
    }
}
