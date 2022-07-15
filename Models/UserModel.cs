using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public Boolean status { get; set; }
    }
}
