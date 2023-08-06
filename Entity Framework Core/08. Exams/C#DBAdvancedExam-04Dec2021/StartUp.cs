using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Theatre.Data;
using Theatre.DataProcessor;

namespace C_DBAdvancedExam_04Dec2021
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var db = new TheatreContext();
            //db.Database.EnsureDeleted();
            //db.Database.Migrate();

            //string castsXml = File.ReadAllText(@"..\..\..\Datasets\casts.xml");
            //string playsXml = File.ReadAllText(@"..\..\..\Datasets\plays.xml");
            //string theatresTickets = File.ReadAllText(@"..\..\..\Datasets\theatres-and-tickets.json");

            //Console.WriteLine(Deserializer.ImportPlays(db, playsXml));
            //Console.WriteLine(Deserializer.ImportCasts(db, castsXml));
            //Console.WriteLine(Deserializer.ImportTtheatersTickets(db, theatresTickets));

            Console.WriteLine(Serializer.ExportTheatres(db, 10));
            Console.WriteLine(Serializer.ExportPlays(db, 5.5));
        }
    }
}
