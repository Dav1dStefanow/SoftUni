using BoardGamesDatabase.Data;
using BoardGamesDatabase.Data.Models;
using BoardGamesDatabase.Data.Models.Configurations;
using BoardGamesDatabase.Data.Models.Enumerators;
using BoardGamesDatabase.DataProcessor.ImportDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BoardGamesDatabase.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardGamesContext db, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCreatorsBGamesDto[]), new XmlRootAttribute("Creators"));
            var supplierXml = new StringReader(xmlString);
            var result = serializer.Deserialize(supplierXml) as ImportCreatorsBGamesDto[];
            StringBuilder sb = new StringBuilder();
            List<Creator> creators = new List<Creator>();

            foreach (var c in result)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var creator = new Creator
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                };

                foreach (var boardgame in c.BoardGames)
                {
                    if (!IsValid(boardgame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var boardGame = new BoardGame
                    {
                        Name = boardgame.Name,
                        Rating = boardgame.Rating,
                        YearPublished = boardgame.YearPublished,
                        CategoryType = (CategoryType)boardgame.CategoryType,
                        Mechanics = boardgame.Mechanics,
                    };
                    creator.Games.Add(boardGame);

                }
                creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Games.Count));
            }
            db.Creators.AddRange(creators);
            db.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardGamesContext db, string jsonString)
        {

            var sellersJson = JsonConvert.DeserializeObject<IEnumerable<ImportSellersDto>>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Seller> sellers = new List<Seller>();

            foreach (var sellerDto in sellersJson)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var seller = new Seller
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    WebSite = sellerDto.WebSite,
                };
                foreach(var boargame in sellerDto.BoardGames.Distinct())
                {
                    if(!db.BoardGames.Any(bg => bg.Id == boargame))
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        var bds = new BoardGameSeller
                        {
                            BoardGameId = boargame,
                        };
                        seller.BoardGameSellers.Add(bds);
                    }
                }
                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardGameSellers.Count));
            }
            db.Sellers.AddRange(sellers);
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
