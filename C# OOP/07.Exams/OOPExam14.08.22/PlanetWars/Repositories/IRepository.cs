using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }
        T FindByName(string typeName);
        void AddItem(T item);
        bool RemoveItem(string typeName);
    }
}
