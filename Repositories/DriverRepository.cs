using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DbUtility;
using System.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp.Repositories
{

    public interface IDriverRepository: IGenericRepository<Driver>
    {

    }

    public class DriverRepository : IDriverRepository
    {
        private DBConnection db = new DBConnection();

        public List<Driver> GetAll()
        {
            List<Driver> drivers = new List<Driver>();
            db.connect();
            string sql = "select * from drivers";
            db.InitCommand(sql);
            using(MySqlDataReader reader = db.ExecuteReader())
            {
                Driver driver = new Driver();
                while (reader.Read())
                {
                    Driver drvr = new Driver();
                    drvr.Id = Convert.ToInt32(reader["id"]);
                    drvr.Name = reader["Name"].ToString();
                    drvr.ContactNo = reader["contact_no"].ToString();
                    drvr.AddedData = Convert.ToDateTime(reader["added_date"]);

                    if (!reader.IsDBNull(reader.GetOrdinal("modified_date")))
                    {
                        drvr.ModifiedDate = Convert.ToDateTime(reader["modified_date"]);
                    }

                    drvr.Status = Convert.ToBoolean(reader["Status"]);
                           
                    

                    driver.AddedData = Convert.ToDateTime(reader["modified_date"]);

                    drivers.Add(drvr);
                }
            }
            db.Close();
            return drivers;
        }

        public int Insert(Driver model)
        {
            db.connect();
            string sql = "insert into drivers(name,contact_no,status) values (@DriverName,@ContactNo,@Status)";
            db.InitCommand(sql);
            db.AddParamater("@DriverName", model.Name, DbType.AnsiString);
            db.AddParamater("@ContactNo",model.ContactNo,DbType.AnsiString);
            db.AddParamater("@Status",model.Status, DbType.Boolean);

            int result = db.ExecuteNonQuery();
            db.Close();
            return result;

        }

        public int Update(Driver model)
        {
            throw new NotImplementedException();
        }
    }
}
