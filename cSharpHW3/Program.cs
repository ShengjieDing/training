using System;

namespace antrahw3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4 };
            foreach (int item in arr1) { Console.Write(item + " "); }
            Console.WriteLine();


            int[] arr2 = { 4, 3, 2, 1, 0 };
            foreach (int item in arr2) { Console.Write(item + " "); }
            Console.WriteLine();

            arr2 = arr1;
            foreach (int item in arr2) { Console.Write(item + " "); }
            Console.WriteLine();


        }
    }
}
