using System;
using System.Collections.Generic;

namespace P00.EntityFrameworkIntroductionLecture.Model;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressText { get; set; }

    public int? TownId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Town Town { get; set; }
}
