using System;

namespace LeapYear
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Leap Year Checker ---");
            Console.WriteLine("Please enter a year and hit [Enter] to check if it's a leap year.");

            int year = Int32.Parse(Console.ReadLine());
            string answer = IsLeapYear(year) == true ? "yay" : "nay";
            Console.WriteLine(answer);
        }

        public static bool IsLeapYear(int year)
        {
            if (year == 0) return false;
            if (year % 4 == 0 && year % 100 != 0) return true;
            else if (year % 400 == 0) return true;
            return false;
        }
    }
}
