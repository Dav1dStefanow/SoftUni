using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace P03.PlayersAndMonsters.Heroes.Wizards
{
    internal class SoulMaster : Wizard
    {
        public SoulMaster(string username, int level)
           : base(username, level)
        {
            Username = username;
            Level = level;
        }
    }
}
