using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw3
{
    class MyList<T>
    {
        private T[] genericList;
        private int count;
        private readonly T[] emptyArr = new T[0];
        public MyList()
        {
            genericList = emptyArr;
        }
        void Add(T item) 
        {
            T[] newList = new T[count + 1];
            Array.Copy(genericList, newList, count);
            newList[count + 1] = item;
            count++;
            genericList = newList;
        }
        T Remove(int ind)
        {
            T[] newList = new T[count + 1];
            T item = genericList[ind];
            for (int i = 0; i < count; i++)
            { 
                if (i != ind) 
                { 
                    newList[i] = genericList[i]; 
                } 
            }
            count--;
            genericList = newList;
            return item;
        }
        bool Contains(T element)
        {
            for (int i = 0; i< count; i++)
            {
                if(genericList[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        void Clear()
        {
            genericList = new T[0];
        }

        void InsertAt(T element, int ind)
        {
            T[] newList = new T[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i < ind - 1)
                {
                    newList[i] = genericList[i];
                }
                else if (i == ind - 1)
                {
                    newList[i] = element;
                }
                else
                {
                    newList[i] = genericList[i - 1];
                }
            }
            count++;
            genericList = newList;
        }
        void DeleteAt(T element, int ind)
        {
            Remove(ind);    
        }
        T Find(int ind)
        {
            return (genericList[ind]);
        }
    }
}
