using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._2
{
    class Courses: ICourse
    {
        private string[] Students;
        public string[] GetStudents()
        {
            return (Students);
        }
    }
}
