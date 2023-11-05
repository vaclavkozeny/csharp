using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcLinq.Models
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public override string ToString()
        {
            return FirstName + " " + EmployeeId;
        }
    }
}
