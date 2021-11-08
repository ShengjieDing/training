using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw3
{
    class GenericRepository<T>: IRepository<T>
    {
        private IEnumerable<T> itemList; 
        
        public void Add(T element)
        {
            itemList = itemList.Append(element);
        }
        public void Remove(T element) 
        { IEnumerable<T> newList = Enumerable.Empty<T>();
            foreach(T item in itemList)
            {
                if (!item.Equals(element)) { newList = newList.Append(item); }
            }
            itemList = newList;
        }
        public void Save() { }

        public IEnumerable<T> GetAll() { return itemList; }
        public T GetById(int id) { return itemList.ElementAt(id); }

    }
}
