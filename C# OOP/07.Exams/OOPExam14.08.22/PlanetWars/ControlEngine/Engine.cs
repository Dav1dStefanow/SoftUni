using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.ControlEngine
{
    public class Engine
    {
        private Controller controller;
        public Engine() 
        { 
            this.controller = new Controller();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Peace")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (tokens[0] == "CreatePlanet")
                    {
                        string planetName = tokens[1];
                        double budget = double.Parse(tokens[2]);
                        Console.WriteLine(controller.CreatePlanet(planetName, budget));
                    }
                    else if (tokens[0] == "AddUnit")
                    {
                        string unitTypeName = tokens[1];
                        string planetName = tokens[2];
                        Console.WriteLine(controller.AddUnit(unitTypeName, planetName));
                    }
                    else if (tokens[0] == "AddWeapon")
                    {
                        string planetName = tokens[1];
                        string weaponTypeName = tokens[2];
                        int destructionLevel = int.Parse(tokens[3]);
                        Console.WriteLine(controller.AddWeapon(planetName, weaponTypeName, destructionLevel));
                    }
                    else if (tokens[0] == "SpecializeForces")
                    {
                        string planetName = tokens[1];
                        Console.WriteLine(controller.SpecializeForces(planetName));
                    }
                    else if (tokens[0] == "SpaceCombat")
                    {
                        string firstPlanetName = tokens[1];
                        string secondPlanetName = tokens[2];
                        Console.WriteLine(controller.SpaceCombat(firstPlanetName, secondPlanetName));
                    }
                    else if (tokens[0] == "ForcesReport")
                    {
                        Console.WriteLine(controller.ForcesReport());
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
