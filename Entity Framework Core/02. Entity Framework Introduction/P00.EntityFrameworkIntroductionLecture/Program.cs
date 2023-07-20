using P00.EntityFrameworkIntroductionLecture.Model;
using System;
using System.Linq;

namespace P00.EntityFrameworkIntroductionLecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Microsoft.EntityFrameworkCore.SqlServer
            //Microsoft.EntityFrameworkCore.Design
            //dotnet ef dbcontext list
            /* dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true;
             * TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Model -f -d*/
            var db = new SoftUniContext();
            Console.WriteLine(db.Employees.Count());
            var employeesBySalay = db.Employees
                .Where(x => x.Salary > 10000)
                .Select(x => new { x.FirstName, x.LastName, x.Salary })
                .Take(10).ToList();
            foreach( var employee in employeesBySalay )
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} => " +
                    $"{employee.Salary}");
            }
        }
    }
}
