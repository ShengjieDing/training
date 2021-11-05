using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._4
{
    public class Order
    {

        private readonly Guid OrderNumber;
        public Guid orderNumber { get { return OrderNumber;} }

        private string OrderName;
        public string orderName { get {return OrderName;} }

        private DateTime OrderDate;
        public DateTime orderDate { get { return OrderDate; } }

        public Order()
        {
        }
        public Order(string str)
        {
            OrderNumber = Guid.NewGuid();
            OrderName = str;
            OrderDate = DateTime.Now;
        }
        public Order(string str, DateTime time)
        {
            OrderNumber = Guid.NewGuid();
            OrderName = str;
            OrderDate = time;
        }
        public Order(string str, Guid guid, DateTime time)
        {
            OrderNumber = guid;
            OrderName = str;
            OrderDate = time;
        }
    }
}
