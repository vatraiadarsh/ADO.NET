using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{

    public interface IDriverRepository: IGenericRepository<Driver>
    {

    }

    public class DriverRepository : IDriverRepository
    {
        public int Insert(Driver model)
        {
            throw new NotImplementedException();
        }

        public int Update(Driver model)
        {
            throw new NotImplementedException();
        }
    }
}
