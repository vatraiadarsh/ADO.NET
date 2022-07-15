using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.DbUtility;
using System.Data;

namespace ConsoleApp.Repositories
{

    public interface IDriverRepository: IGenericRepository<Driver>
    {

    }

    public class DriverRepository : IDriverRepository
    {
        private DBConnection db = new DBConnection();
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
