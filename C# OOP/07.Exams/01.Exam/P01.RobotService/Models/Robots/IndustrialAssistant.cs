using P01.RobotService;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Robots
{
    public class IndustrialAssistant : Robot
    {
        private const int batteryCapacity = 40000;
        private const int convertionCapacityIndex = 5000;
        public IndustrialAssistant(string model)
            : base(model)
        {
            this.BatteryLevel = batteryCapacity;
            this.BatteryCapacity = batteryCapacity;
            this.ConvertionCapacityIndex = convertionCapacityIndex;
        }
    }
}
