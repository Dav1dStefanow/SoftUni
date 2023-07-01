using P01.RobotService.Models.Robots;
using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.RobotService.Controllers
{
    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;
        public Controller(RobotRepository robots, SupplementRepository supplements)
        {
            this.robots = robots;
            this.supplements = supplements;
        }

        public IReadOnlyCollection<IRobot> Robots => this.robots.Collection;
        public IReadOnlyCollection<ISupplement> Supplements => this.supplements.Collection;

        public string CreateRobot(string model, string typeName)
        {
            if (typeName == nameof(DomesticAssistant))
            {
                IRobot robot = new DomesticAssistant(model);
                this.robots.AddNew(robot);
                return $"DomesticAssistant {model} is created and added to the RobotRepository.";
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                IRobot robot = new IndustrialAssistant(model);
                this.robots.AddNew(robot);
                return $"IndustrialAssistant {model} is created and added to the RobotRepository.";
            }
            return $"Robot type {typeName} cannot be created.";
        }
        public string CreateSupplement(string typeName)
        {
            if (typeName == nameof(LaserRadar))
            {
                ISupplement supp = new LaserRadar();
                this.supplements.AddNew(supp);
                return $"{typeName} is created and added to the SupplementRepository.";

            }
            else if (typeName == nameof(SpecializedArm))
            {
                ISupplement supp = new SpecializedArm();
                this.supplements.AddNew(supp);
                return $"{typeName} is created and added to the SupplementRepository.";
            }
            return $"{typeName} is not compatible with our robots.";
        }
        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = this.robots.Models().Where(r => r.InterfaceStandards.Any(i => i == interfaceStandard)).OrderByDescending(y => y.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return $"Unable to perform service, {interfaceStandard} not supported!";
            }
            int powerSum = selectedRobots.Sum(r => r.BatteryLevel);

            if (powerSum < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - powerSum} more power needed.";
            }

            int usedRobotsCount = 0;

            foreach (var robot in selectedRobots)
            {
                usedRobotsCount++;

                if (totalPowerNeeded <= robot.BatteryLevel)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }

            }
            return $"{serviceName} is performed successfully with {usedRobotsCount} robots.";

        }

        public void Report()
        {
            foreach (IRobot robot in this.robots.Collection)
            {
                Console.WriteLine(robot);
            }
        }

        public string RobotRecovery(string model, int minutes)
        {
            int fedBots = 0;
            foreach (IRobot robot in this.robots.Collection)
            {
                if (robot.Model == model && robot.BatteryLevel <= robot.BatteryCapacity / 2)
                {
                    robot.Eating(minutes);
                    fedBots++;
                }
            }
            return $"Robots fed {fedBots}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supp = this.supplements.Collection.FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            bool areAllUpgraded = false;
            foreach (IRobot robot in this.robots.Collection)
            {
                if (robot.Model == model && (!robot.InterfaceStandards.Contains(supp.InterfaceStandard)))
                {
                    areAllUpgraded = true;
                    robot.InstallSupplement(supp);
                    Console.WriteLine($"{model} is upgraded with {supplementTypeName}.");
                }
            }
            if (areAllUpgraded)
            {
                return $"{model} is upgraded with {supplementTypeName}.";
            }
            return $"All {model} are already upgraded!";
        }
    }
}
