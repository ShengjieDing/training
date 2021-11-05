using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._2
{
    class Dept:IDept
    {
        private string HeadOfDept;
        private decimal Budget;
        private string[] Courses;
        public string GetHeadofDept()
        {
            return (HeadOfDept);
        }
        public decimal GetBudget()
        {
            return (Budget);
        }
        public string[] GetCourses()
        {
            return (Courses);
        }
    }
}
