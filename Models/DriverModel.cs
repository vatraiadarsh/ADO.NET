using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }

        public DateTime AddedData { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Boolean Status { get; set; }
    }
}
