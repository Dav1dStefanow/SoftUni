using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PlayersAndMonsters.Heroes.Elfs
{
    internal class MuseElf : Elf
    {
        public MuseElf(string username, int level)
           : base(username, level)
        {
            Username = username;
            Level = level;
        }
    }
}
