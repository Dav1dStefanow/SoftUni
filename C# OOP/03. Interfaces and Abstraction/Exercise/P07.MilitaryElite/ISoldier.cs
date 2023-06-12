using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MilitaryElite
{
    public interface ISoldier : IPrivate
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Id { get; set; }
    }
}
