namespace Theatre.DataProcessor
{
    using C_DBAdvancedExam_04Dec2021.DataProcessor.ImportModels;
    using C_DBAdvancedExam_04Dec2021.Models;
    using C_DBAdvancedExam_04Dec2021.Models.Enumerators;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext db, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPlaysDto[]), new XmlRootAttribute("Plays"));
            var playsXml = new StringReader(xmlString);
            var result = serializer.Deserialize(playsXml) as ImportPlaysDto[];
            StringBuilder sb = new StringBuilder();
            List<Play> plays = new List<Play>();

            foreach (var palyDto in result)
            {
                if (!IsValid(palyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;
                bool IsDurationValid = TimeSpan.TryParseExact(palyDto.Duration, "hh\\:mm\\:ss",
                CultureInfo.InvariantCulture, TimeSpanStyles.None, out duration);

                if (!IsDurationValid || duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool IsGenreValid = Enum.TryParse<Genre>(palyDto.Genre, out Genre genre);

                if (!IsGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                double rating = palyDto.Rating;

                var play = new Play
                {
                    Title = palyDto.Title,
                    Duration = duration,
                    Rating = rating,
                    Genre = genre,
                    Description = palyDto.Description,
                    ScreenWriter = palyDto.ScreenWriter
                };
                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }
            db.AddRange(plays);
            db.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportCasts(TheatreContext db, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCastsModel[]), new XmlRootAttribute("Casts"));
            var castsXml = new StringReader(xmlString);
            var result = serializer.Deserialize(castsXml) as ImportCastsModel[];
            StringBuilder sb = new StringBuilder();
            List<Cast> casts = new List<Cast>();

            foreach (var castDto in result)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string character = castDto.IsMainCharacter == true ? character = "main" : character = "lesser";

                var cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, character));
            }
            db.AddRange(casts);
            db.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext db, string jsonString)
        {
            var theatresJson = JsonConvert.DeserializeObject<IEnumerable<ImportTheatresTicketsModel>>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Theatre> theatres = new List<Theatre>();

            foreach (var theatreDto in theatresJson)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                };

                foreach (var ticketDto in theatreDto.Tickets.Distinct())
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };
                    theatre.Tickets.Add(ticket);
                }
                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }
            db.AddRange(theatres);
            db.SaveChanges();
            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
