using System.Data;
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
                connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
                connection.Open();
                Console.WriteLine("DB connected");

                while (true)
                {
                    Console.WriteLine("Username");
                    String username = Console.ReadLine();
                    Console.WriteLine("Password");
                    String password = Console.ReadLine();

                    string sql = "select * from users where username=@username and password = @password ";

                    MySqlCommand SqlCommand = new MySqlCommand();
                    SqlCommand.CommandText = sql;
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Connection = connection;

                    SqlCommand.Parameters.Add(new MySqlParameter()
                    {
                        DbType = DbType.AnsiString,
                        ParameterName = "username",
                        Value = username,
                    });

                    SqlCommand.Parameters.Add(new MySqlParameter()
                    {
                          
                        DbType = DbType.AnsiString,
                        ParameterName = "Password",
                        Value = password,
                    });

                    using (MySqlDataReader reader = SqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["username"]);
                            Console.WriteLine(reader["password"]);
                            Console.WriteLine(reader["status"]);
                            Console.WriteLine("------------------------------------------");
                        }
                        connection.Close();
                    }
                }

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