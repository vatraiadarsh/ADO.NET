using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DbUtility
{
    public class DBConnection
    {
        private MySqlConnection connection = null;
        private MySqlCommand cmd = null;

        public void connect()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "Server=localhost;Database=ado;Uid=root;Pwd=''";
            connection.Open();
        }

        public void InitCommand(String sql)
        {
            cmd = new MySqlCommand(sql);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
        }

        public void AddParamater(string paramName, object value, DbType type)
        {
            MySqlParameter SqlParam = new MySqlParameter();
            SqlParam.DbType = type;
            SqlParam.ParameterName = paramName;
            SqlParam.Value = value;
            cmd.Parameters.Add(SqlParam);

        }

        public int ExecuteNonQuery()
        {
            return cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            connection.Close();
            connection = null;
        }
    }
}
