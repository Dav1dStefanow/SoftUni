using System;
using System.Collections.Generic;
using System.Text;

namespace P01.RobotService.Controllers
{
    public interface IRepository<T>
    {
        IReadOnlyList<T> Collection { get; }
        IReadOnlyList<T> Models();
        void AddNew(T model);
        bool RemoveByName(string typeName);
        T FindByStandard(int  standardId);
    }
}
