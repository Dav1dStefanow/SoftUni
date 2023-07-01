
using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.SystemControl
{
    public interface IController
    {
        SubjectRepository Subjects { get; }
        UniversityRepository Universities { get; }
        StudentRepository Students { get; }
        string AddSubject(string subjectName, string subjectType);
        string AddUniversity(string universityName, string category, int capacity, List<int> requiredSubjects);
        string AddStudent(string firstName,  string lastName);
        string TakeExam(int studentId, int subjectId);
        string ApplyToUniversity(string studentName, string universityName);
        string UniversityReport(int universityId);
    }
}
