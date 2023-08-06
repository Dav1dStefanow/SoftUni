using BoardGamesDatabase.Data;
using System;
using System.IO;
using BoardGamesDatabase.Data.Models;
using BoardGamesDatabase.Data.Models.Enumerators;
using BoardGamesDatabase.DataProcessor.ImportDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BoardGamesDatabase.DataProcessor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BoardGamesDatabase
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var db = new BoardGamesContext();
            //db.Database.EnsureDeleted();
            //db.Database.Migrate();

            //string creatorsXml = File.ReadAllText("../../../Datasets/creators.xml");
            //string sellersJson = File.ReadAllText("../../../Datasets/sellers.json");

            //Console.WriteLine(Deserializer.ImportCreators(db, creatorsXml));
            //Console.WriteLine(Deserializer.ImportSellers(db, sellersJson));

            Console.WriteLine(Serializer.ExportSellersWithMostBoardgames(db, 2018, 8.0));
            Console.WriteLine(Serializer.ExportCreatorsWithTheirBoardgames(db));
        }
    }
}
