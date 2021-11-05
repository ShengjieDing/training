using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._2
{
    class Instructor: Person,IInstructor
    {
        private string Dept;
        private bool Head;
        private DateTime JoinDate;

        public string GetDept() {
            return (Dept);
        }
        public int Bonus() {
            DateTime currentDate = DateTime.Now;
            int experience = (int)(currentDate - JoinDate).TotalDays;
            return (2000 * experience / 365);
        }
        public override decimal GetSalary()
        {
            return (Salary + Bonus());
        }

    }
}
