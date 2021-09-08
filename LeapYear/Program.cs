using System;

namespace LeapYear
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(IsLeapYear(400));
        }

        public static bool IsLeapYear(int year)
        {
            if(year == 0) return false;
            if(year % 4 == 0 && year % 100 != 0) return true;
            else if(year % 400 == 0) return true;
            return false;
        }
    }
}
