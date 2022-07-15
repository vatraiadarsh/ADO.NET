using ConsoleApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DbUtility;

namespace ConsoleApp.Repositories
{
    public interface IUserRepository: IGenericRepository<User>
    {

    }
    public class UserRepository : IUserRepository
    {

        private DBConnection db = new DBConnection();

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(User user)
        {
            db.connect();
            String sql = "insert into users(username,email,password,status) values(@userName,@email,@password,@status)";
            db.InitCommand(sql);

            db.AddParamater("@username", user.userName, DbType.AnsiString);
            db.AddParamater("@email", user.email, DbType.AnsiString);
            db.AddParamater("@password", user.password, DbType.AnsiString);
            db.AddParamater("@status", user.status, DbType.Boolean);


            int result = db.ExecuteNonQuery();

            db.Close();
            return result;

        }

        public int Update(User user)
        {

            db.connect();
            string sql = "update users set username=@username, email=@email,password=@password,status=@status where id=@id";

            db.InitCommand(sql);

            db.AddParamater("@username", user.userName, DbType.AnsiString);
            db.AddParamater("@email", user.email, DbType.AnsiString);
            db.AddParamater("@password", user.password, DbType.AnsiString);
            db.AddParamater("@status", user.status, DbType.Boolean);
            db.AddParamater("@id", user.Id, DbType.Int32);


            int result = db.ExecuteNonQuery();

            db.Close();
            return result;

        }

        




    }  
}


       