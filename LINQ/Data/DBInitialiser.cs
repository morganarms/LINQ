using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQ.Data
{
    public static class DBInitialiser
    {
        public static void Initialize(LINQDBContext context)
        {
            context.Database.EnsureCreated();

            if(context.Employee.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee { FirstName = "Blake", LastName = "Purdue", DepartmentId = 1, Age = 20, Email = "blake@ahp.co.nz", Salary = 45000, Gender = "Male"},
                new Employee { FirstName = "David", LastName = "Harris", DepartmentId = 1, Age = 26, Email = "david@ahp.co.nz", Salary = 12000, Gender = "Male"},
                new Employee { FirstName = "Morgan", LastName = "Armitage", DepartmentId = 1, Age = 26, Email = "morgan@ahp.co.nz", Salary = 60000, Gender = "Female"},
                new Employee { FirstName = "Jane", LastName = "Doe", DepartmentId = 2, Age = 31, Email = "jane@ahp.co.nz", Salary = 27000, Gender = "Female"},
                new Employee { FirstName = "John", LastName = "Smith", DepartmentId = 2, Age = 28, Email = "john@ahp.co.nz", Salary = 32000, Gender = "Male"},
                new Employee { FirstName = "Bob", LastName = "Thebuilder", DepartmentId = 2, Age = 35, Email = "bob@ahp.co.nz", Salary = 25000, Gender = "Male"},
            };

            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }

            context.SaveChanges();
        }
    }
}
