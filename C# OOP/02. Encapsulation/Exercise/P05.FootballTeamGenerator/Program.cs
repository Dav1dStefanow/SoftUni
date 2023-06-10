using System;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace P05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] teamInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                Team team = new Team(teamInfo[1]);
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0] == "Add")
                    {
                        Player player = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                        team.AddPlayer(player);
                    }
                    else if (tokens[0] == "Remove")
                    {
                        team.RemovePlayer(tokens[2]);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        Console.WriteLine(team);
                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
