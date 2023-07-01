using P01.RobotService.Models.Robots;
using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Controllers
{
    public interface IController
    {
        IReadOnlyCollection<IRobot> Robots { get; }
        IReadOnlyCollection<ISupplement> Supplements { get; }
        string CreateRobot(string model, string typeName);
        string CreateSupplement(string typrName);
        string UpgradeRobot(string model, string supplementTypeName);
        string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded);
        string RobotRecovery(string model, int minutes);
        void Report();
    }
}
