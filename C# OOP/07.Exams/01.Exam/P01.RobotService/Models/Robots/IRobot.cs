using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Robots
{
    public interface IRobot
    {
        string Model { get; }
        int BatteryCapacity { get; }
        int BatteryLevel { get; }
        int ConvertionCapacityIndex { get; }
        IReadOnlyList<int> InterfaceStandards { get; }
        void Eating(int minutes);
        void InstallSupplement(ISupplement supp);
        bool ExecuteService(int consumedEnergy);
    }
}
