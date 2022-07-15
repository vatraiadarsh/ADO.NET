using ConsoleApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    public interface IUserRepository
    {
        int Insert(User user);
    }
    internal class UserRepository : IUserRepository
    {
        public int Insert(User user)
        {
            MySqlConnection connection = null;

           
                connection = new MySqlConnection();
                connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
                connection.Open();
                Console.WriteLine("DB connected");

                while (true)
                {
                    Console.WriteLine("Username");
                    String username = Console.ReadLine();
                    Console.WriteLine("Email");
                    String email = Console.ReadLine();
                    Console.WriteLine("Password");
                    String password = Console.ReadLine();
                    Console.WriteLine("Status");
                    String status = Console.ReadLine();

                    string sql = "insert into users(username,email,password,status)" +
                        "values(@username,@email,@password,@status)";



                    MySqlCommand command = new MySqlCommand(sql);
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Add(new MySqlParameter()
                    {
                        ParameterName = "@username",
                        Value = username,
                        DbType = DbType.AnsiString,
                    });
                command.Parameters.Add(new MySqlParameter()
                {
                    ParameterName = "@email",
                    Value = email,
                    DbType = DbType.AnsiString,
                });
                command.Parameters.Add(new MySqlParameter()
                    {
                        ParameterName = "@password",
                        Value = password,
                        DbType = DbType.AnsiString,
                    });

                    command.Parameters.Add(new MySqlParameter()
                    {
                        ParameterName = "@status",
                        Value = status,
                        DbType = DbType.Boolean,
                    });

                    int result = command.ExecuteNonQuery();
            
                    connection.Clone();
                    return result;

                }
           
        }
    }
}
    

