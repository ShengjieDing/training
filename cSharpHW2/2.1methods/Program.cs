using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace antrahw2
{
    class Program
    {
        public static int Holidays(string start, string end)
        {
            Dictionary<string, string> allholidays = new Dictionary<string, string>();
            allholidays.Add("Jan 01","New Year's");
            allholidays.Add("Jan 18", "MLK");
            allholidays.Add("Jan 20", "Inauguration");
            allholidays.Add("Feb 15", "Washington");
            allholidays.Add("May 31", "Memorial");
            allholidays.Add("Jun 18", "Juneteenth");
            allholidays.Add("Jul 05", "Independence");
            allholidays.Add("Sep 06", "Labor");
            allholidays.Add("Oct 11", "Columbus");
            allholidays.Add("Nov 11", "Veterans");
            allholidays.Add("Nov 25", "Thanksgiving");
            allholidays.Add("Dec 24", "Christmas");



            start = Regex.Replace(start, @"[^0-9]+"," ").Trim();
            end = Regex.Replace(end, @"[^0-9]+", " ").Trim();
            int[] startDate = Array.ConvertAll(start.Split(" "), s => int.Parse(s));
            int[] endDate = Array.ConvertAll(end.Split(" "), s => int.Parse(s));
            DateTime d1 = new DateTime(startDate[2], startDate[0], startDate[1], 0, 0, 0);
            DateTime d2 = new DateTime(endDate[2], endDate[0], endDate[1], 0, 0, 0);
            int totaldays = (int)(d2 - d1).TotalDays;

            while (d1.Date != d2.Date)
            {
                if ((d1.DayOfWeek == DayOfWeek.Saturday |
                    d1.DayOfWeek == DayOfWeek.Sunday) &
                    allholidays.ContainsKey(d1.ToString("MMM dd")))
                {
                    totaldays--;
                }
            }
            return totaldays;
            //DateTime firstWeekend = new DateTime(startDate[2], startDate[1], startDate[0], 0, 0, 0);
            //for (int i = 0; i < 7; i++)
            //{
            //    if(firstWeekend.DayOfWeek == DayOfWeek.Saturday |
            //        firstWeekend.DayOfWeek == DayOfWeek.Sunday)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        firstWeekend = firstWeekend.AddDays(1);
            //    }
            //}

            //int weekends = (int)(d2 - firstWeekend).TotalDays / 7;
            //Console.WriteLine(weekends);
            //Console.WriteLine(totaldays);
            //totaldays = totaldays - (weekends * 2);
            //Console.WriteLine(totaldays);
        }
        public static int Fibonacci(int num)
        {
            int l = 1;
            int r = 1;
            int res = 0;
            if(num == 1)
            {
                return 1;
            }
            if (num == 2)
            {
                return 1;
            }
            for(int i = 3; i <= num; i++)
            {
                res = l + r;
                l = r;
                r = res;
            }
            return res;
        }
        public static int[] GenerateNumbers(int length = 10)
        {
            return Enumerable.Range(1, length).ToArray();
        }
        public static void Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            //int l = 0;
            //int r = numbers.Length - 1;
            //while (l < r)
            //{
            //    int temp = numbers[l];
            //    numbers[l] = numbers[r];
            //    numbers[r] = temp;
            //    l++;
            //    r--;
            //}
        }
        public static void PrintNumbers(int[] numbers)
        {
            foreach (int item in numbers) { Console.Write(item + " "); }
        }
        static void Main(string[] args)
        {
            1.1
            int[] numbers = GenerateNumbers();
            Reverse(numbers);
            PrintNumbers(numbers);

            1.2
            Console.WriteLine(Fibonacci(8));

            //1.3
            string start = "/02-01-2020/";
            string end = "/01-01-2021/";
            Console.WriteLine(Holidays(start, end));

        }
    }
}
