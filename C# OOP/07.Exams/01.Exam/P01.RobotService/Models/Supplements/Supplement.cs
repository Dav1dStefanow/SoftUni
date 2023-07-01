using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Supplements
{
    public class Supplement : ISupplement
    {
        public int InterfaceStandard { get; protected set; }

        public int BatteryUsage { get; protected set; }
    }
}
