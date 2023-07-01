using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.RobotService.Controllers
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;
        public SupplementRepository() 
        { 
            this.supplements = new List<ISupplement>();
        }
        public IReadOnlyList<ISupplement> Collection => this.supplements;

        public void AddNew(ISupplement supplement)
        {
            supplements.Add(supplement);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplements.FirstOrDefault(p => p.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyList<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            if(supplements.Any(s => s.GetType().Name == typeName))
            {
                supplements.Remove(supplements.First(s => s.GetType().Name == typeName));   
                return true;
            }
            return false;
        }
    }
}
