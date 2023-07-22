using P01.MusicHubDatabase.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace P01.MusicHubDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicHubContext();
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(ExportAlbumsInfo(db, input));
        }
        //problem 3
        public static string ExportSongsAboveDuration(MusicHubContext db, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = db.Songs
               .ToList()
               .Where(s => s.Duration.TotalSeconds > duration)
               .Select(s => new
               {
                   Name = s.Name,
                   Writer = s.Writer.Name,
                   PerformerFullName = s.SongPerformers
                       .ToList()
                       .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").FirstOrDefault(),
                   AlbumProducer = s.Album.Producer.Name,
                   Duration = s.Duration.ToString("c")
               })
               .OrderBy(s => s.Name)
               .ThenBy(s => s.Writer)
               .ThenBy(s => s.PerformerFullName)
               .ToList();

            int count = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }


            return sb.ToString();
        }
        // problem 2
        public static string ExportAlbumsInfo(MusicHubContext db, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = db.Albums
               .ToArray()
               .Where(a => a.ProducerId == producerId)
               .OrderByDescending(a => a.Price)
               .Select(a => new
               {
                   AlbumName = a.Name,
                   ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                   ProducerName = a.Producer.Name,
                   AlbumSongs = a.Songs
                                   .ToArray()
                                   .Select(s => new
                                   {
                                       SongName = s.Name,
                                       Price = s.Price.ToString("f2"),
                                       WriterName = s.Writer.Name
                                   })
                                   .OrderByDescending(s => s.SongName)
                                   .ThenBy(s => s.WriterName)
                                   .ToArray(),
                   TotalPrice = a.Price.ToString("f2")
               })
               .ToArray();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int songsCounter = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{songsCounter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice}");
            }


            return sb.ToString();
        }
    }
}
