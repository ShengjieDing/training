using System;

namespace antrahw2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ball b1 = new Ball();
            Ball b2 = new Ball();
            b2.Pop();
            b1.Throw();
            b2.Throw();
            Console.WriteLine(b1.GetThrowCount());
            Console.WriteLine(b2.GetThrowCount());

        }
    }
}
