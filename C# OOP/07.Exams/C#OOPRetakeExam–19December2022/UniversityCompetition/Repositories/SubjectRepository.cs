using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Models.Universities;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> subjects;
        public SubjectRepository()
        {
            this.subjects = new List<ISubject>();
        }
        public IReadOnlyCollection<ISubject> Models => this.subjects;

        public void AddModel(ISubject university)
        {
            this.subjects.Add(university);
        }

        public ISubject FindById(int id)
        {
            ISubject sub = this.subjects.FirstOrDefault(x => x.Id == id);
            return sub;
        }

        public ISubject FindByName(string name)
        {
            ISubject sub = this.subjects.FirstOrDefault(x => x.Name == name);
            return sub;
        }
    }
}
