using P01.RobotService;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Supplements
{
    public class SpecializedArm : Supplement
    {
        private const int batteryUsage = 10000;
        private const int interfaceStandard = 10045;
        public SpecializedArm()
        {
            this.BatteryUsage = batteryUsage;
            this.InterfaceStandard = interfaceStandard;
        }
    }
}
