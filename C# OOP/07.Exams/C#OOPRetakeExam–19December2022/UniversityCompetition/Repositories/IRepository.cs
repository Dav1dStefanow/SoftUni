using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Repositories
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }
        void AddModel(T model); 
        T FindById(int  id);
        T FindByName(string name);
    }
}
