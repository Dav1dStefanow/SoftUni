using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;

namespace UniversityCompetition.Models.Students
{
    public interface IStudent
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        IReadOnlyCollection<int> CoveredExams  { get; }
        IUniversity University { get; }
        void CoverExam(ISubject subject);
        void JoinUniversity(IUniversity university);
    }
}
