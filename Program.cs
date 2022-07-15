using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                userName = "jack",
                password = "jack",
                status = true

            };

            IUserRepository repo = new UserRepository();
            int result = repo.Insert(user);
            Console.WriteLine(result);
        }
    }
}