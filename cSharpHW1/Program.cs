using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _02UnderstandingTypes
{
    class Program
    {
        //2.4
        public static void parseURL(string str)
        {
            Uri res = new Uri(str);
            string protocal = res.Scheme;
            Console.WriteLine(protocal);
            string host = res.Authority;
            Console.WriteLine(host);
            string resource = string.Join("",res.Segments);
            Console.WriteLine(resource);

        }
        //2.3
        public static string GetPalindrome(string str)
        {
            char[] separator = { ' ', '.' , ',', ';', ':', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?'};
            string[] separated = str.Split(separator);
            StringBuilder res = new StringBuilder();
            separated = separated.Where(i => i.SequenceEqual(i.Reverse())).ToArray();
            separated = separated.Where(i => !string.IsNullOrEmpty(i)).ToArray();
            foreach (var item in separated)
            {
                Console.WriteLine(item);
            }
            Array.Sort(separated);
            return string.Join(" ", separated);
        }
        //2.2
        public static string reverseSentence(string str) {
            char[] separator = {' ', '.' ,',', ';',':','=','(',')','&','[',']','"','\'','\\','/','!','?' };
            string[] separated = System.Text.RegularExpressions.Regex.Split(str, @"([ \.\,\;\:\=\(\)\&\[\]\'\'\\/!\?])");
            separated = separated.Where(i => i != " ").ToArray();
            separated = separated.Where(i => !string.IsNullOrEmpty(i)).ToArray();
            //foreach (string item in separated) { Console.Write(item); }
            int l = 0;
            int r = separated.Length - 1;
            while (l < r)
            {
                if (separated[l].Length == 1)
                {
                    if (separator.Contains(char.Parse(separated[l])))
                    {
                        l++;
                    }
                }
                else if (separated[r].Length == 1)
                {
                    if (separator.Contains(char.Parse(separated[r])))
                    {
                        r--;
                    }
                }
                else
                {
                    string tmp = separated[l];
                    separated[l] = separated[r];
                    separated[r] = tmp;
                    l++;
                    r--;
                }
            }
            StringBuilder result = new StringBuilder();
            result.Append(separated[0]);
            for (int i = 1; i < separated.Length; i++)
            {
                if (separated[i].Length == 1)
                {
                    char temp = separated[i][0];
                    if (separator.Contains(temp))
                    {
                        result.Append(separated[i]);
                    }
                }
                else
                {
                    result.Append(" " + separated[i]);
                }
            }
            
            return result.ToString(); 
        }
        //2.1
        public static string reversestr1(string str) {
            char[] arr = str.ToArray();
            Array.Reverse(arr);
            string reverse = "";
            for (int i = str.Length-1; i>= 0; i--)
            {
                reverse = reverse + str[i];
            }
            return new string(arr);
        }
        //2-7
        public static int[] mostRep(int[] arr)
        {
            Dictionary<int,int> nums = new Dictionary<int, int>();
            for(int i = 0; i < arr.Length; i++)
            {
                if (nums.ContainsKey(arr[i])){
                    nums[arr[i]]++;
                }
                else
                {
                    nums.Add(arr[i],1);
                }
            }
            int maxkey = nums.OrderByDescending(x => x.Value).First().Key;
            int[] maxval = new int[] { maxkey ,nums[maxkey]};
            return maxval;
        }
        //2-5
        public static string longestSubArray(int[] arr)
        {
            int longest = arr[0];
            int curr = arr[0];
            int rep = 1 , currrep = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] == arr[i - 1])
                {
                    currrep++;
                }

                else
                {
                    if(rep < currrep)
                    {
                        longest = arr[i-1];
                    }
                    rep = Math.Max(rep,currrep);
                    currrep = 1;
                    curr = arr[i];
                }
            }
            if (currrep > rep)
            {
                longest = curr;
                rep = currrep;
            }

            string res = new StringBuilder().Insert(0, $"{longest}", 1).Insert(0, $"{longest}, ", rep - 1).ToString();
            return res;
        }
        //2-4
        public static int[] rotate(string numbers, int rotation)
        {
            string[] strnum = numbers.Split(' ');
            int[] intnum = Array.ConvertAll(strnum, s => int.Parse(s));
            int[] sum = new int[intnum.Length];

            for (int i = 1; i <= rotation; i++)
            {
                int temp = intnum[intnum.Length - 1];
                for (int j =  intnum.Length - 1; j>0; j--)
                {
                    intnum[j] = intnum[j - 1];
                }
                intnum[0] = temp;

                for (int k = 0; k < intnum.Length; k++)
                {
                    sum[k] += intnum[k];
                }
            }
            return sum;
        }
        //2-3
        public static int[] FindPrimesInRange(int startNum,int endNum)
        {
            List<int> allprime = new List<int>();
            bool[] primes = new bool[endNum + 1];
            for (int i = 0; i < endNum; i++)
            {
                primes[i] = true;
            }
            for (int i = 2; i*i < endNum; i++)
            {
                if(primes[i] == true)
                {
                    for(int j = i*i; j <= endNum; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            for ( int i = startNum; i <= endNum; i++)
            {
                if(primes[i] == true)
                {
                    allprime.Add(i);
                }
            }
            return allprime.ToArray();
        }
        //2-2
        public static void loopitem()
        {
            Dictionary<string, int> groceryList = new Dictionary<string, int>();
            for (; ; )
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                string userinp = Console.ReadLine();
                string[] command = userinp.Split(' ');
                if(command[0] == "+")
                {
                    if (groceryList.ContainsKey(command[1]))
                    {
                        groceryList[command[1]] += 1;
                    }
                    else
                    {
                        groceryList.Add(command[1], 1);
                    }
                }
                else if (command[0] == "-")
                {
                    if (groceryList.ContainsKey(command[1]))
                    {
                        groceryList[command[1]] -= 1;
                        if(groceryList[command[1]] == 0)
                        {
                            groceryList.Remove(command[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no item by this name");
                    }
                }
                else if (command[0] == "--")
                {
                    groceryList.Clear();
                }
                else
                {
                    Console.WriteLine("invalid command");
                }
                foreach (var data in groceryList)
                {
                    Console.WriteLine($"{ data.Key}: {data.Value}");
                }
            }

        }
        public static void countTo24()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 24; j += i)
                {
                    Console.Write(j + ",");
                }
                Console.WriteLine("");
            }
        }
        public static void greeting()
        {
            int time = (int)DateTime.Now.TimeOfDay.TotalHours;
            if(time > 6 & time < 12){
                Console.WriteLine("Good Morning");
            }
            else if(time > 12 & time < 18)
            {
                Console.WriteLine("Good Afternoon");
            }
            else if(time > 18 & time < 23)
            {
                Console.WriteLine("Good Evening");
            }
            else
            {
                Console.WriteLine("Good Night");
            }
        }
        public static int DaysOld(DateTime birthday)
        {
            var currdate = DateTime.Today;
            return (currdate - birthday).Days;
        }
        public static void pyramid(int level) {
            int len = 2 * level + 1;
            for (int i = 0; i < level; i++) {
                StringBuilder str = new StringBuilder("", len);
                for(int j = 0; j <= len; j++)
                {
                    if (j < (len/2-i) | j > (len/2+i)){
                        str.Append(" "); 
                    }
                    else { 
                        str.Append("*"); 
                    }
                }
                Console.WriteLine(str);
            }
        }
        public static void fizzbuzz()
        {
            Stopwatch timer = new Stopwatch();
            int max = 500;
            timer.Start();
            for (byte i = 0; i < max; i++)
            {
                Console.WriteLine(i);
                if(timer.ElapsedMilliseconds > 500)
                {
                    break;
                }
            }
            timer.Stop();

        }
        public  static string guessnumber(int target, int guess)
        {   

            if (guess == target){
                return "Correct";
            }
            if (guess < 1 | guess > 3){
                return "Guess out of bound";
            }
            if (guess < target)
            {
                return "Low";
            }
            else
            {
                return "High";
            }
        }
        public static string conversion(uint century)
        {
            uint years = century * 100;
            uint days = years * (365 + 97 / 400);
            uint hours = days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            ulong miliseconds = seconds * 100;
            ulong microseconds = miliseconds * 100;
            ulong nanoseconds = microseconds * 100;            
            return ($"{century} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} miliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }

        static void Main(string[] args)
        {
            ////1-1.
            //Console.WriteLine($"sbyte, Byte size: 8-bit, Max Value: {sbyte.MaxValue}, Min Value: {sbyte.MaxValue}");
            //Console.WriteLine($"byte, Byte size: 8-bit, Max Value: {byte.MaxValue}, Min Value: {byte.MaxValue}");
            //Console.WriteLine($"short, Byte size: 16-bit, Max Value: {short.MaxValue}, Min Value: {short.MaxValue}");
            //Console.WriteLine($"ushort, Byte size: 16-bit, Max Value: {ushort.MaxValue}, Min Value: {ushort.MaxValue}");
            //Console.WriteLine($"int, Byte size: 32-bit, Max Value: {int.MaxValue}, Min Value: {int.MaxValue}");
            //Console.WriteLine($"uint, Byte size: 32-bit, Max Value: {uint.MaxValue}, Min Value: {uint.MaxValue}");
            //Console.WriteLine($"long, Byte size: 64-bit, Max Value: {long.MaxValue}, Min Value: {long.MaxValue}");
            //Console.WriteLine($"ulong, Byte size: 64-bit, Max Value: {ulong.MaxValue}, Min Value: {ulong.MaxValue}");
            //Console.WriteLine($"float, Byte size: 4-bit, Max Value: {float.MaxValue}, Min Value: {float.MaxValue}");
            //Console.WriteLine($"double, Byte size: 8-bit, Max Value: {double.MaxValue}, Min Value: {double.MaxValue}");
            //Console.WriteLine($"decimal, Byte size: 16-bit, Max Value: {decimal.MaxValue}, Min Value: {decimal.MaxValue}");

            ////1-2.
            Console.WriteLine(conversion(5));

            ////1-1.
            //fizzbuzz();
            //int correctNumber = new Random().Next(3) + 1;
            //int guessedNumber = int.Parse(Console.ReadLine());
            //Console.WriteLine(guessnumber(correctNumber, guessedNumber));

            ////1-2.
            //pyramid(5);

            ////1-3.
            //correctNumber = new Random().Next(3) + 1;
            //guessedNumber = int.Parse(Console.ReadLine());
            //Console.WriteLine(guessnumber(correctNumber, guessedNumber));

            ////1-4
            //var birthday = new DateTime(1995, 11, 13, 0, 0, 0);
            //int daysince = DaysOld(birthday);
            //Console.WriteLine(daysince);
            //var currdate = DateTime.Today;
            //var nextTenThousand = currdate.AddDays(10000);
            //Console.WriteLine(nextTenThousand);

            ////1-5
            //var currenttime = DateTime.Now;
            //greeting();

            ////1-6
            //countTo24();

            ////2 - 1
            //int[] arr1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arr2 = new int[arr1.Length];
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    arr2[i] = arr1[i];
            //}
            //foreach (int item in arr1) { Console.Write(item); }
            //Console.WriteLine();
            //foreach (int item in arr2) { Console.Write(item); }

            ////2-2
            //loopitem();

            ////2-3
            //int[] primes = FindPrimesInRange(50, 100);
            //foreach (int item in primes) { Console.WriteLine(item); }

            ////2-4
            //int[] rotatedsum = rotate("3 2 4 -1", 2);
            //foreach (var item in rotatedsum) { Console.Write(item + ", "); }
            //Console.WriteLine();

            //rotatedsum = rotate("1 2 3 4 5", 3);
            //foreach (var item in rotatedsum) { Console.Write(item + ", "); }
            //Console.WriteLine();

            ////2-5
            //int[] longestarr = new int[] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1, };
            //string longest = longestSubArray(longestarr);
            //Console.WriteLine(longest);
            //int[] longestarr2 = new int[] { 1, 1, 1, 2, 3, 1, 3, 3 };
            //longest = longestSubArray(longestarr2);
            //Console.WriteLine(longest);
            //int[] arr3 = new int[] { 4, 4, 4, 4 };
            //longest = longestSubArray(arr3);
            //Console.WriteLine(longest);

            ////2-7
            //int[] reparr = new int[] { };
            //int[] maxvalue = mostRep(reparr);
            //foreach (var item in maxvalue) { Console.Write(item + " "); }

            ////Strings
            ////2-1
            //string str = Console.ReadLine();
            //string reversedstr = reversestr1(str);
            //reversestr1(str);
            //Console.WriteLine(reversedstr);

            ////2-2
            //string revstr = "C# is not C++7, and PHP is not Delphi!";
            //string reversedSentance = reverseSentence(revstr);
            //Console.WriteLine(reversedSentance);

            ////2-3
            //string palistr = "Hi,exe? ABBA!Hog fully a string: ExE.Bob";
            //string palindrome = GetPalindrome(palistr);
            //Console.WriteLine(palindrome);

            ////2-4
            //string url = "https://www.apple.com/iphone/";
            //parseURL(url);
        }
    }
}
