using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int DepartmentId { get; set; }

        public double Salary { get; set; }

        public int Age { get; set; }

        public string FullName
        {
            get 
            { 
                return FirstName + " " + LastName; 
            }
        }

    }
}
