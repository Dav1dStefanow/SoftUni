using BoardGamesDatabase.Data;
using BoardGamesDatabase.Data.Models;
using BoardGamesDatabase.DataProcessor.ExportDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Formatting = Newtonsoft.Json.Formatting;

namespace BoardGamesDatabase.DataProcessor
{
    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardGamesContext db)
        {
            StringBuilder sb = new StringBuilder();
            const string rootElement = "Creators";

            var creators = db.Creators
                .Select(x => new ExportCreatorsBGames
                {
                    CreatorName = x.FirstName + " " + x.LastName,
                    BoardGames = x.Games
                    .Select(c => new BoardGameExport
                    {
                        BoardgameName = c.Name,
                        BoardgameYearPublished = c.YearPublished,
                    })

                    .ToArray(),
                    BoardGamesCount = x.Games.Count()
                })
                .ToList();


            return XMLConverter.Serialize(creators, rootElement);
        }

        public static string ExportSellersWithMostBoardgames(BoardGamesContext db, int year, double rating)
        {
            var sellers = db.Sellers
                .Where(s => s.BoardGameSellers.Any(bg => bg.BoardGame.YearPublished >= year && bg.BoardGame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.WebSite,
                    BoardGames = s.BoardGameSellers
                        .Where(x => x.BoardGame.Rating <= rating && x.BoardGame.YearPublished >= year)
                        .Select(bg => new
                        {
                            Name = bg.BoardGame.Name,
                            Rating = bg.BoardGame.Rating,
                            Mechanics = bg.BoardGame.Mechanics,
                            Category = bg.BoardGame.CategoryType.ToString(),

                        })
                        .OrderByDescending(x => x.Rating)
                        .ThenBy(x => x.Name)
                        .ToList()
                })
                .OrderByDescending(x => x.BoardGames.Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}
