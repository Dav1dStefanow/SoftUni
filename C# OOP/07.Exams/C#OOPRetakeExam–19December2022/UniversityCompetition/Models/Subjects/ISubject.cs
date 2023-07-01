using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Subjects
{
    public interface ISubject
    {
        int Id { get; }
        string Name { get; }
        double Rate { get; }
    }
}
