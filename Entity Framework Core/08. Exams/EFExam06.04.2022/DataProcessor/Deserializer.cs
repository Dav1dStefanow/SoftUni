namespace Footballers.DataProcessor
{
    using EFExam06._04._2022.DataProcessor.ImportModels;
    using EFExam06._04._2022.Models;
    using EFExam06._04._2022.Models.Enumerators;
    using Footballers.Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext db, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCoachesDto[]), new XmlRootAttribute("Coaches"));
            var coachXml = new StringReader(xmlString);
            var result = serializer.Deserialize(coachXml) as ImportCoachesDto[];
            StringBuilder sb = new StringBuilder();
            List<Coach> coaches = new List<Coach>();

            foreach (var coachDto in result)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string nationality = coachDto.Nationality;
                bool isNationalityInvalid = string.IsNullOrEmpty(nationality);

                if (isNationalityInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string name = coachDto.Name;
                bool isNameInvalid = string.IsNullOrEmpty(name);

                if (isNameInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = name,
                    Nationality = nationality,
                };
                foreach(var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractStartDate);

                    if (!isFootballerContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out footballerContractEndDate);

                    if (!isFootballerContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (footballerContractEndDate <= footballerContractStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = new Footballer
                    {
                        Name= footballerDto.Name,
                        BestSkillType = (Skill)footballerDto.BestSkillType,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        PositionType = (Position)footballerDto.PositionType,
                    };
                    coach.Team.Add(footballer);
                }
                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Team.Count));
            }
            db.AddRange(coaches);
            db.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext db, string jsonString)
        {
            var teamsJson = JsonConvert.DeserializeObject<IEnumerable<ImportTeamsDto>>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Team> teams = new List<Team>();

            foreach(var teamDto in teamsJson)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                };

                if (team.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var playerDto in teamDto.Footballers.Distinct())
                {
                    if (!db.Footballers.Any(f => f.Id == playerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var teamFootballer = new TeamFootballer
                    {
                        FootballerId = playerDto,
                    };
                    team.Footballers.Add(teamFootballer);
                }
                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.Footballers.Count));
            }
            db.AddRange(teams);
            db.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
