using Microsoft.EntityFrameworkCore;
using P03.UsingSoftUniDatabase.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace P03.UsingSoftUniDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true;TrustServerCertificate = True" Microsoft.EntityFrameworkCore.SqlServer -o Models */
            //Microsoft.EntityFrameworkCore

            SoftUniContext db = new SoftUniContext();
            Console.WriteLine(RemoveTown(db));
        }
        // problem 15
        public static string RemoveTown(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var emplyeeAddress = db.Employees
                .Where(a => a.Address.Town.Name == "Seattle");
            foreach( var employee in emplyeeAddress )
            {
                employee.Address = null;
            }
            db.SaveChanges();
            var deleteAddresses = db.Addresses.Where(a => a.Town.Name == "Seattle");
            int count = 0;
            foreach ( var address in deleteAddresses )
            {
                db.Addresses.Remove(address);
                count++;
            }
            db.SaveChanges();
            var deleteTown = db.Towns.FirstOrDefault(t => t.Name == "Seattle");
            db.Towns.Remove(deleteTown);
            db.SaveChanges();

            sb.AppendLine($"{count} addresses in Seattle were deleted");
            return sb.ToString().Trim();
        }
            // problem 14
            public static string DeleteProjectById(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var deleteThiis = db.EmployeesProjects.Where(p => p.ProjectId == 2);
            foreach ( var employee in deleteThiis )
            {
                db.EmployeesProjects.Remove(employee);
            }
            db.SaveChanges();
            var deleteThis = db.Projects.Where(p => p.ProjectId == 2);
            foreach (var employee in deleteThis)
            {
                db.Projects.Remove(employee);
            }
            db.SaveChanges();

            var projects = db.Projects
                .Select(p => new { p.Name })
                .Take(10)
                .ToList();
            foreach ( var project in projects )
            {
                sb.AppendLine(project.Name);
            }
            return sb.ToString().Trim();
        }
        // problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var employees = db.Employees
                .Select(e => new
                {
                    e.FirstName
                    ,
                    e.LastName
                    ,
                    e.JobTitle
                    ,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .OrderBy(e => e.LastName)
                .ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - {e.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
        // problem 12
        public static string IncreaseSalaries(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var increaseSalary = db.Employees
                .Select(e => new
                {
                    Salary = (float)e.Salary * 1.12
                    ,
                    e.FirstName
                    ,
                    e.LastName
                    ,
                    Name = e.Department.Name
                })
                .Where(d => d.Name == "Engineering" || d.Name == "Tool Design"
                || d.Name == "Marketing" || d.Name == "Information Services ")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            foreach (var d in increaseSalary)
            {
                sb.AppendLine($"{d.FirstName} {d.LastName} (${d.Salary:F2})");
            }

            return sb.ToString().Trim();
        }
        // problem 11
        public static string GetLatestProjects(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects = db.Projects
                .Select(p => new
                {
                    p.Name
                    ,
                    p.Description
                    ,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .Take(10)
                .ToList();
            foreach (var p in latestProjects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }

            return sb.ToString().Trim();
        }
        // problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var departments = db.Departments
                .Select(d => new
                {
                    d.Name
                    ,
                    d.Manager.FirstName
                    ,
                    d.Manager.LastName
                    ,
                    d.Employees.Count
                    ,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName
                    ,
                        e.LastName
                    ,
                        e.JobTitle
                    }).OrderBy(m => m.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .Where(e => e.Count > 5)
                .OrderBy(e => e.Count)
                .ThenBy(d => d.Name)
                .ThenBy(m => m.FirstName)
                .ThenBy(m => m.LastName)
                .ToList();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");
                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }
            return sb.ToString().Trim();
        }
        //problem 9
        public static string GetEmployee147(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var employee = db.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Where(p => p.EmployeeId == 147)
                    .Select(p => new { p.Project.Name })
                    .OrderBy(p => p.Name)
                    .ToList()
                })
                .ToList();
            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine(p.Name);
                }
            }

            return sb.ToString().Trim();
        }
        // pronoblem 8
        public static string GetAddressesByTown(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employees = db.Addresses
                .Select(a => new
                {
                    Address = a.AddressText,
                    TownName = a.Town.Name,
                    a.Employees.Count
                })
                .OrderByDescending(e => e.Count)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.Address)
                .Take(10).ToList();
            foreach (var a in employees)
            {
                sb.AppendLine($"{a.Address}, {a.TownName} - {a.Count} employees");
            }

            return sb.ToString().Trim();
        }
        // problem 7
        public static string GetEmployeesInPeriod(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var employees = db.Employees
                .Where(e => e.EmployeesProjects
                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        }).ToList()
                }).ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }
        // problem 6
        public static string AddNewAddressToEmployee(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            db.Addresses.Add(address);
            db.SaveChanges();
            var nakov = db.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");
            nakov.AddressId = address.AddressId;
            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => new { x.Address })
                .Take(10).ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Address.AddressText}");
            }
            return sb.ToString().Trim();
        }
        // problem 3
        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var employeeFullInfo = db.Employees
                .Select(x => new { x.FirstName, x.MiddleName, x.LastName, x.JobTitle, x.Salary })
                .ToList();
            foreach (var e in employeeFullInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.MiddleName} {e.LastName} {e.JobTitle} {e.Salary}");
            }

            return sb.ToString().Trim();
        }
        // problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();
            var employeeFullInfo = db.Employees
                .Select(x => new { x.FirstName, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();
            foreach (var e in employeeFullInfo)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
        // problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            StringBuilder sb = new StringBuilder();

            var employeeFullInfo = db.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new { x.FirstName, x.LastName, x.Department, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();
            foreach (var e in employeeFullInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }

}
