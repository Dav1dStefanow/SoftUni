namespace Theatre.DataProcessor
{
    using C_DBAdvancedExam_04Dec2021;
    using C_DBAdvancedExam_04Dec2021.DataProcessor.ExportModels;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext db, int numbersOfHalls)
        {
            var theatres = db.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    t.Name,
                    t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Select(p => new
                    {
                        p.Price,
                        p.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToList()
                })
                .OrderByDescending(c => c.NumberOfHalls)
                .ThenBy(c => c.Name)
                .ToList();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext db, double raiting)
        {
            const string rootElement = "Plays";

            var plays = db.Plays
                .Where(r => r.Rating <= raiting)
                .Select(p => new ExportPlaysModel
                {
                    Title = p.Title,
                    Duration = p.Duration,
                    Rating = p.Rating == 0? "Premier" : $"{p.Rating}",
                    Genre = p.Genre,
                    Actors = p.Actors
                    .Select(a => new ActorXml
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    }).ToArray()
                }).ToArray();

            return XMLConverter.Serialize(plays, rootElement);
        }
    }
}
