using System;
using System.Collections.Generic;

namespace P00.EntityFrameworkIntroductionLecture.Model;

public partial class Town
{
    public int TownId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
