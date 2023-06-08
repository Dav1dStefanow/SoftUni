using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PlayersAndMonsters.Heroes.Wizards
{
    internal class Wizard : Hero
    {
        public Wizard(string username,int level)
            :base(username,level)
        {
            Username = username;
            Level= level;
        }
    }
}
