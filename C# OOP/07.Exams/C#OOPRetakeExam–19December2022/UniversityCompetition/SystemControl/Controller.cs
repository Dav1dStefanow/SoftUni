using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Students;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.SystemControl
{
    public class Controller : IController
    {
        private StudentRepository studentRepository;
        private SubjectRepository subjectRepository;
        private UniversityRepository universityRepository;

        public Controller()
        {
            this.studentRepository = new StudentRepository();
            this.subjectRepository = new SubjectRepository();
            this.universityRepository = new UniversityRepository();
        }
        public SubjectRepository Subjects => this.subjectRepository;

        public UniversityRepository Universities => this.universityRepository;

        public StudentRepository Students => this.studentRepository;

        public string AddStudent(string firstName, string lastName)
        {
            if (studentRepository.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }
            IStudent student = new Student(this.studentRepository.Models.Count + 1, firstName, lastName);
            this.studentRepository.AddModel(student);
            return $"Student {firstName} {lastName} is added to the {this.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType == nameof(EconomicalSubject))
            {
                if (subjectRepository.Models.Any(s => s.Name == subjectName))
                {
                    return $"{subjectName} is already added in the repository.";
                }
                ISubject subject = new EconomicalSubject(this.subjectRepository.Models.Count + 1, subjectName);
                this.subjectRepository.AddModel(subject);
                return $"{subjectType} {subjectName} is created and added to the {this.GetType().Name}!";
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                if (subjectRepository.Models.Any(s => s.Name == subjectName))
                {
                    return $"{subjectName} is already added in the repository.";
                }
                ISubject subject = new TechnicalSubject(this.subjectRepository.Models.Count + 1, subjectName);
                this.subjectRepository.AddModel(subject);
                return $"{subjectType} {subjectName} is created and added to the {this.GetType().Name}!";
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                if (subjectRepository.Models.Any(s => s.Name == subjectName))
                {
                    return $"{subjectName} is already added in the repository.";
                }
                ISubject subject = new HumanitySubject(this.subjectRepository.Models.Count + 1, subjectName);
                this.subjectRepository.AddModel(subject);
                return $"{subjectType} {subjectName} is created and added to the {this.GetType().Name}!";
            }
            else return $"Subject type {subjectType} is not available in the application!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<int> requiredSubjects)
        {
            if (Universities.Models.Any(s => s.Name == universityName))
            {
                return $"{universityName} is already added in the repository.";
            }
            IUniversity uni = new University(this.Universities.Models.Count + 1, universityName, category, capacity, requiredSubjects);
            this.Universities.AddModel(uni);
            return $"{universityName} is added to the {this.GetType().Name}!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (!studentRepository.Models.Any(s => s.Id == studentId))
            {
                return "Invalid student ID!";
            }
            if (!subjectRepository.Models.Any(s => s.Id == subjectId))
            {
                return "Invalid subject ID!";
            }
            IStudent student = studentRepository.FindById(studentId);
            ISubject sub = subjectRepository.FindById(subjectId);
            if (student.CoveredExams.Contains(subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {sub.GetType().Name}.";
            }
            student.CoverExam(sub);
            return $"{student.FirstName} {student.LastName} covered {sub.GetType().Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = Universities.FindById(universityId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {university.AdmittedStudentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - university.AdmittedStudentsCount}");
            return sb.ToString().Trim();
        }
        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] names = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (!studentRepository.Models.Any(s => s.FirstName == names[0] && s.LastName == names[1]))
            {
                return $"{names[0]} {names[1]} is not registered in the application!";
            }
            if (!universityRepository.Models.Any(u => u.Name == universityName))
            {
                return $"{universityName} is not registered in the application!";
            }
            IStudent student = studentRepository.Models.First(s => s.FirstName == names[0] && s.LastName == names[1]);
            IUniversity uni = universityRepository.Models.First(u => u.Name == universityName);
            if (!HasPassed(uni, student))
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }
            student.JoinUniversity(uni);
            foreach(var univ in universityRepository.Models)
            {
                if(univ.Name == universityName)
                {
                    univ.AdmittedStudentsCount++;
                }
            }
            return $"{student.FirstName} {student.LastName} has already joined {uni.Name}.";
        }
        private bool HasPassed(IUniversity uni, IStudent stu)
        {
            foreach(var exam in uni.RequiredSubjects)
            {
                if(!stu.CoveredExams.Contains(exam))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
