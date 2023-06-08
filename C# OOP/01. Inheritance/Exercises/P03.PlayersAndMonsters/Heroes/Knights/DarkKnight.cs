using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PlayersAndMonsters.Heroes.Knights
{
    internal class DarkKnight : Knight
    {
        public DarkKnight(string username, int level)
           : base(username, level)
        {
            Username = username;
            Level = level;
        }
    }
}
