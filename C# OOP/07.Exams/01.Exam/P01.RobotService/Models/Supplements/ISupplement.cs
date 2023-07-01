using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Models.Supplements
{
    public interface ISupplement
    {
        int InterfaceStandard { get; }

        int BatteryUsage { get; }

    }
}
