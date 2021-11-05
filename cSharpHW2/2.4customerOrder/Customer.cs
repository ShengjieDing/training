using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._4
{
    public class Customer: Order
    {
        private string FirstName;
        public string firstname { get { return FirstName; } set { FirstName = value; } }
        private string LastName;
        public string lastname { get { return LastName; } set { LastName = value; } }

        private readonly string Name;
        public string name { get { return (FirstName + " " + LastName); }  }

        private string Email;
        public string email { get { return Email; } set { Email = value; } }

        private List<Order> OrderHistory = new List<Order>();
        public List<Order> orderHistory { get { return OrderHistory; } }

        public Customer(string fn, string ln, string em)
        {
            firstname = fn;
            lastname = ln;
            email = em;
        }
        public List<Order> GetOrderHistory()
        {
            return OrderHistory;
        }
        public void AddOrder(string str, DateTime time)
        {
            if(time <= DateTime.Today & str != null)
            {
                Order newOrd = new Order(str, time);
                OrderHistory.Add(newOrd);
            }
        }
        //public void AddOrder(Order o)
        //{
        //    if (o.orderDate.Equals(DateTime.Today) & o.orderName != null)
        //    { 
        //        OrderHistory.Add(o);
        //    }
        //}

    }
}
