using P01.StudentSystem.Data;
using System;

namespace P01.StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureCreated();
        }
    }
}
