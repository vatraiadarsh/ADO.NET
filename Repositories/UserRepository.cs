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
        int Update(User user);
    }
    internal class UserRepository : IUserRepository
    {
        public int Insert(User user)
        {
            MySqlConnection connection = null;


            connection = new MySqlConnection();
            connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
            connection.Open();
            String sql = "insert into users(username,email,password,status) values(@userName,@email,@password,@status)";

            MySqlCommand command = new MySqlCommand(sql);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@username",
                Value = user.userName,
                DbType = DbType.AnsiString,
            });
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@email",
                Value = user.email,
                DbType = DbType.AnsiString,
            });
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@password",
                Value = user.password,
                DbType = DbType.AnsiString,
            });

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@status",
                Value = user.status,
                DbType = DbType.Boolean,
            });

            int result = command.ExecuteNonQuery();

            connection.Clone();
            return result;

        }

        public int Update(User user)
        {
            MySqlConnection connection = null;


            connection = new MySqlConnection();
            connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
            connection.Open();


            string sql = "update users set username=@username, email=@email,password=@password,status=@status where id=@id";



            MySqlCommand command = new MySqlCommand(sql);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@username",
                Value = user.userName,
                DbType = DbType.AnsiString,
            });
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@email",
                Value = user.email,
                DbType = DbType.AnsiString,
            });
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@password",
                Value = user.password,
                DbType = DbType.AnsiString,
            });

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@status",
                Value = user.status,
                DbType = DbType.Boolean,
            });
            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "@id",
                Value = user.Id,
                DbType = DbType.Int32
            });

            int result = command.ExecuteNonQuery();

            connection.Clone();
            return result;

        }
    }
}


       