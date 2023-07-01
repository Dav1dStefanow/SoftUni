using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;

namespace UniversityCompetition.Models.Students
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;
        public Student(int studentId, string firstName, string lastName)
        {
            this.Id = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;

            this.coveredExams = new List<int>();
        }
        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => this.coveredExams;

        public IUniversity University
        {
            get { return this.university; }
            private set { this.university = value; }
        }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}
