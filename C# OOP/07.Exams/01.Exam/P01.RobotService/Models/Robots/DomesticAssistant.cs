using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Robots
{
    public class DomesticAssistant : Robot
    {
        private const int batteryCapacity = 20000;
        private const int convertionCapacityIndex = 2000;
        public DomesticAssistant(string model) 
            : base(model)
        {
            this.BatteryLevel = batteryCapacity;
            this.BatteryCapacity = batteryCapacity;
            this.ConvertionCapacityIndex = convertionCapacityIndex;
        }
    }
}
