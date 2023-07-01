using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Students;
using UniversityCompetition.Models.Subjects;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;
        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => this.students;

        public void AddModel(IStudent university)
        {
            this.students.Add(university);
        }

        public IStudent FindById(int id)
        {
            IStudent stu = this.students.FirstOrDefault(x => x.Id == id);
            return stu;
        }

        public IStudent FindByName(string name)
        {
            string[] bothNames = name.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            IStudent stu = this.students.FirstOrDefault(x => x.FirstName == bothNames[0] && x.LastName == bothNames[1]);
            return stu;
        }
    }
}
