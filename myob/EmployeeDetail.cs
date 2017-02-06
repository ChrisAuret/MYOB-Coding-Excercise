using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myob
{
    //  first name
    //  last name
    //  annual salary(positive integer)
    //  super rate(0% - 50%	inclusive)
    //  payment start date

    public class EmployeeDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal SuperRate { get; set; } // (0% - 50%	inclusive)
        public string StartDate { get; set; }
    }
}
