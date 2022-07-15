using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    public interface IGenericRepository<TModel>
    {
        int Insert(TModel model);
        int Update(TModel model);

    }
}
