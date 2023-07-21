using P02.FootballBetting.Data;
using System;

namespace P02.FootballBetting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureCreated();

        }
    }
}
