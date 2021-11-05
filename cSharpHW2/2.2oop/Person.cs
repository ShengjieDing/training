using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._2
{
    public abstract class Person: IPerson
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string[] Addresses { get; set; }
        public virtual decimal Salary { get; set; }
        public int Age { get; set; }
        public int GetAge() {
            return Age;
        }
        public virtual decimal GetSalary()
        {
            return Salary;
        }
        public string[] GetAddresses()
        {
            return Addresses;
        }
    }
}
