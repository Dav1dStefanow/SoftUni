using System;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.SystemControl;

namespace UniversityCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Engine engine = new Engine();
           engine.Run();
        }
    }
}
