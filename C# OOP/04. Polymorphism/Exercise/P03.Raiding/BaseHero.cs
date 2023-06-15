using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.name = name;
        }
        protected string name;
        public string Name => this.name;
        public virtual int Power { get; }
        public abstract string CastAbility();
    }
}
