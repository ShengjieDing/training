using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw3
{
    interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
