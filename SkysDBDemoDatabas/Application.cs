namespace SkysDBDemoDatabas
{
    public class Application
    {
        private readonly string _connectionString;

        public Application(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Run()
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
                    CreateNewUser(dbConnection);
                if (sel == 2)
                    ListAllUsers(dbConnection);

            }

        }
    }
}