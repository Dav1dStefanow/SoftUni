﻿using System;
using System.Collections.Generic;

namespace P00.EntityFrameworkIntroductionLecture.Model;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string JobTitle { get; set; }

    public int DepartmentId { get; set; }

    public int? ManagerId { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public int? AddressId { get; set; }

    public virtual Address Address { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee Manager { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
