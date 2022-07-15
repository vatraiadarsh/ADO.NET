using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = "Server=localhost;Database=apple;Uid=root;Pwd=''";
                connection.Open();
                Console.WriteLine("DB connected");
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}