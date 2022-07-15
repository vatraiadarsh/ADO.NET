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
    public class UserRepository : IUserRepository
    {
       private MySqlConnection connection = null;
        MySqlCommand command = null;


        private void connect()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
            connection.Open();
        }

        private void InitCommand(String sql)
        {
            command = new MySqlCommand(sql);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
        }

        public int Insert(User user)
        {
            connect();
            String sql = "insert into users(username,email,password,status) values(@userName,@email,@password,@status)";
            InitCommand(sql);

            AddParamater("@username", user.userName, DbType.AnsiString);
            AddParamater("@email", user.email, DbType.AnsiString);
            AddParamater("@password", user.password, DbType.AnsiString);
            AddParamater("@status", user.status, DbType.Boolean);


            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;

        }

        public int Update(User user)
        {

            connect();
            string sql = "update users set username=@username, email=@email,password=@password,status=@status where id=@id";

            InitCommand(sql);

            AddParamater("@username", user.userName, DbType.AnsiString);
            AddParamater("@email", user.email, DbType.AnsiString);
            AddParamater("@password", user.password, DbType.AnsiString);
            AddParamater("@status", user.status, DbType.Boolean);
            AddParamater("@id", user.Id, DbType.Int32);


            int result = command.ExecuteNonQuery();

            connection.Close();
            return result;

        }

        private void AddParamater(string paramName, object value, DbType type)
        {
            MySqlParameter param = new MySqlParameter();
            param.DbType = type;
            param.ParameterName = paramName;
            param.Value = value;
            cmd.Parameters.Add(cmd);

        }




    }  
}


       