 namespace Footballers.DataProcessor
{
    using Data;
    using EFExam06._04._2022;
    using EFExam06._04._2022.DataProcessor.ExportModels;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext db)
        {
            const string rootElement = "Coaches";

            var coachesFootballers = db.Coaches
                .Select(c => new ExportCoachesFootballersModel
                {
                    CoachName = c.Name,
                    Footballers = c.Team.Select(p => new FootballerXml
                    { 
                        Name = p.Name,
                        Position = p.PositionType,
                    })
                    .OrderBy(p => p.Name)
                    .ToArray(),
                    FootballersCount = c.Team.Count()
                })
                .OrderByDescending(f => f.FootballersCount)
                .ThenBy(p => p.CoachName)
                .ToArray();

            return XMLConverter.Serialize(coachesFootballers, rootElement);
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext db, DateTime date)
        {
            var teamsFootballers = db.Teams
                .Where(t => t.Footballers.Any(p => p.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.Footballers
                    .Where(p => p.Footballer.ContractStartDate >= date)
                    .Select(f => new
                    {
                        Name = f.Footballer.Name,
                        ContractStartDate =  f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate =  f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = f.Footballer.BestSkillType,
                        PositionType =  f.Footballer.PositionType,
                    })
                    .OrderByDescending(p => p.ContractEndDate)
                    .ThenBy(p => p.Name).ToList()
                })
                .OrderByDescending(f => f.Footballers.Count())
                .ThenBy(n => n.Name)
                .Take(5).ToList();

            return JsonConvert.SerializeObject(teamsFootballers, Formatting.Indented);
        }
    }
}
