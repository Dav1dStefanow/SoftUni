using P01.RobotService.Models.Robots;
using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.RobotService.Controllers
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository()
        {
            this.robots = new List<IRobot>();
        }
        public IReadOnlyList<IRobot> Collection => this.robots;

        public void AddNew(IRobot supplement)
        {
            robots.Add(supplement);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(r => r.InterfaceStandards.Any(i => i == interfaceStandard));
        }

        public IReadOnlyList<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            if (robots.Any(s => s.GetType().Name == typeName))
            {
                robots.Remove(robots.First(s => s.GetType().Name == typeName));
                return true;
            }
            return false;
        }
    }
}

