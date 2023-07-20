using Microsoft.EntityFrameworkCore;
using P00.EntityFrameworkConstructionLecture.Model;
using System;
using System.Linq;

namespace P00.EntityFrameworkConstructionLecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Microsoft.EntityFrameworkCore.SqlServer
            //Microsoft.EntityFrameworkCore.Design
            //dotnet ef migrations add InitialCreate
            //dotnet ef database update == db.Database.Migrate();

            var db = new SliDoDbContext();
            db.Database.Migrate();
            db.Database.EnsureCreated();
        }
    }
}