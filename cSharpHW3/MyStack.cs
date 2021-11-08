using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw3
{
    public class MyStack<T>
    {
        private int myCount;
        public int MyCount 
        {
            get { return myCount; }
            set { myCount = value; }
        }
        private List<T> myList;
        public int MyList
        {
            get { return MyList; }
            set { MyList = value; }
        }
        int Count() { return MyCount; }

        T Pop(){
            T item = myList[myList.Count-1];
            myList.RemoveAt(myList.Count-1);
            myCount--;
            return item;
        }
        void Push(T item)
        {
            myList.Add(item);
            myCount++;
        }
    }
}
