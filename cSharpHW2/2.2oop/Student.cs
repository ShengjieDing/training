using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._2
{
    public class Student: Person, IStudent
    {
        private string[] courses;
        private Tuple<string, int>[] grades;
        
        string[] GetCourses() {
            return courses;
        }
        public float GetGpa() {
            float gpa = 0;
            foreach (Tuple<string, int> x in grades)
            {
                gpa += x.Item2;
            }
            return gpa / grades.Length;
        }
        public string GetGrade (string temp){
            foreach (Tuple<string, int> x in grades)
            {
                if(temp == x.Item1)
                {
                    if(x.Item2 < 60)
                    {
                        return "F";
                    }
                    if (x.Item2 >= 60 & x.Item2 < 70)
                    {
                        return "D";
                    }
                    if (x.Item2 >= 70 & x.Item2 < 80)
                    {
                        return "C";
                    }
                    if (x.Item2 >= 80 & x.Item2 < 90)
                    {
                        return "B";
                    }
                    if (x.Item2 >= 90)
                    {
                        return "A";
                    }
                }
            }
            return "No such course";
        }
    }
}
