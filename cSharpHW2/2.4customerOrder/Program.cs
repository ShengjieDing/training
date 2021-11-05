using System;

namespace antrahw2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("John", "Doe","abc@xyz.com");
            Order o1 = new Order("coffee");
            
            c1.AddOrder("coffee", DateTime.Today);
            c1.AddOrder("water", DateTime.Today.AddDays(-1));
            c1.AddOrder("Tea", DateTime.Today.AddDays(1));
            c1.AddOrder(null, DateTime.Today);

            foreach (var item in c1.GetOrderHistory()) 
            {
                Console.WriteLine(item.orderName + " " + item.orderNumber + " " + item.orderDate);
            }
        }
    }
}
