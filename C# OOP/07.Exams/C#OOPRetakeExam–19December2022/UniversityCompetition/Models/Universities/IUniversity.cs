using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.Universities
{
    public interface IUniversity
    {
        int Id { get; }
        string Name { get; }
        string Category { get; }
        int Capacity { get; }
        int AdmittedStudentsCount { get; set; }
        IReadOnlyCollection<int> RequiredSubjects { get; }
    }
}
