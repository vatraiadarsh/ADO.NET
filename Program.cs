using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* User user = new User()
             {
                 Id = 6,
                 userName = "Kyle",
                 email = "kyle@gmail.com",
                 password = "kyle",
                 status = true

             };



             IUserRepository repo = new UserRepository();
             //int result = repo.Insert(user);
             int result = repo.Update(user);
             Console.WriteLine(result);

            */


            IDriverRepository driverRepository = new DriverRepository();
            int result = driverRepository.Insert(new Driver()
            {
                Name = "James",
                ContactNo = "0421334233",
                Status = false

            });

            Console.WriteLine(result);



        }
    }
}