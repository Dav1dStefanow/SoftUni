using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandards;
        protected Robot(string model)
        {
            this.Model = model;
            this.interfaceStandards = new List<int>();
        }
        public string Model
        {
            get { return model; }
            protected set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentNullException("Model cannot be null or empty.");
                }
                model = value;
            }
        }
        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Battery capacity cannot drop below zero.");
                }
                batteryCapacity = value;
            }
        }
        public int BatteryLevel
        {
            get { return batteryLevel; }
            protected set { batteryLevel = value; }
        }
        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            protected set { convertionCapacityIndex = value; }
        }
        public IReadOnlyList<int> InterfaceStandards => this.interfaceStandards;

        public void Eating(int minutes)
        {
            for(int i = 0; i < minutes;i++)
            {
                if(BatteryLevel + ConvertionCapacityIndex >= BatteryCapacity)
                {
                    BatteryLevel = BatteryCapacity;
                    break;
                }
                BatteryLevel += ConvertionCapacityIndex;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(BatteryLevel - consumedEnergy >= 0)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            BatteryLevel = 0;
            return false;
        }

        public void InstallSupplement(ISupplement supp)
        {
            if(!InterfaceStandards.Any(p => p == supp.InterfaceStandard))
            {
                interfaceStandards.Add(supp.InterfaceStandard);
                BatteryLevel -= supp.BatteryUsage;
                BatteryCapacity -= supp.BatteryUsage;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.AppendLine($"--Supplements installed: {string.Join(" ", InterfaceStandards)}");
            return sb.ToString().Trim();
        }
    }
}
