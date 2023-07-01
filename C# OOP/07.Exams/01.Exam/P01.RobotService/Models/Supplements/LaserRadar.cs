using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Supplements
{
    public class LaserRadar : Supplement
    {
        private const int batteryUsage = 5000;
        private const int interfaceStandard = 20082;
        public LaserRadar()
        {
            this.BatteryUsage = batteryUsage;
            this.InterfaceStandard = interfaceStandard;
        }
    }
}
