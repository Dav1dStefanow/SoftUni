using P01.RobotService.Controllers;
using P01.RobotService.Models.Robots;
using P01.RobotService.Models.Supplements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P01.RobotService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RobotRepository bots = new RobotRepository();
            SupplementRepository supps = new SupplementRepository();
            Controller controller = new Controller(bots, supps);
            string command;
            while ((command = Console.ReadLine()) != "Exit")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "CreateRobot")
                {
                    Console.WriteLine(controller.CreateRobot(tokens[1], tokens[2]));

                }
                else if (tokens[0] == "CreateSupplement")
                {
                    Console.WriteLine(controller.CreateSupplement(tokens[1]));

                }
                else if (tokens[0] == "UpgradeRobot")
                {
                    Console.WriteLine(controller.UpgradeRobot(tokens[1], tokens[2]));

                }
                else if (tokens[0] == "PerformService")
                {
                    Console.WriteLine(controller.PerformService(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3])));


                }
                else if (tokens[0] == "RobotRecovery")
                {
                    Console.WriteLine(controller.RobotRecovery(tokens[1], int.Parse(tokens[2])));

                }
                else if (tokens[0] == "Report")
                {
                    controller.Report();

                }
            }
        }
    }
}
