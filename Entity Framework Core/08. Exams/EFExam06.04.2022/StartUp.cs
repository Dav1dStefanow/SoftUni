using Footballers.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Footballers.DataProcessor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EFExam06._04._2022
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new FootballersContext();
            //db.Database.EnsureDeleted();
            //db.Database.Migrate();

            //var coachesXml = File.ReadAllText(@"..\..\..\Datasets\coaches.xml");
            //var teamsJson = File.ReadAllText(@"..\..\..\Datasets\teams.json");

            //Console.WriteLine(Deserializer.ImportCoaches(db, coachesXml));
            //Console.WriteLine(Deserializer.ImportTeams(db, teamsJson));

            Console.WriteLine(Serializer.ExportCoachesWithTheirFootballers(db));
        }
    }
}
