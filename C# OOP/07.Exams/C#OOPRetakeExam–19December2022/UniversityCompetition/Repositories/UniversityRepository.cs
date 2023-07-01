using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Universities;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universities;
        public UniversityRepository()
        {
            this.universities = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models => this.universities;

        public void AddModel(IUniversity university)
        {
            this.universities.Add(university);
        }

        public IUniversity FindById(int id)
        {
            IUniversity uni = this.universities.FirstOrDefault(x => x.Id == id);
            return uni;
        }

        public IUniversity FindByName(string name)
        {
            IUniversity uni = this.universities.FirstOrDefault(x => x.Name == name);
            return uni;
        }
    }
}
