using System;

namespace LeapYear
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Leap Year Checker ---");
            Console.WriteLine("Please enter a year and hit [Enter] to check if it's a leap year.");

            LeapYearChecker checker = new LeapYearChecker(1582);

            try {
                int year = Int32.Parse(Console.ReadLine());
                Console.WriteLine(checker.IsLeap(year));
            } catch(FormatException) {
                Console.WriteLine("ERROR: Only numbers are accepted!");
            } catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
        }

        public static bool IsLeapYear(int year)
        {
            if (year == 0) return false;
            if (year % 4 == 0 && year % 100 != 0) return true;
            else if (year % 400 == 0) return true;
            return false;
        }
    }

    public class LeapYearChecker 
    {
        private int minYear;
        public LeapYearChecker(int minYear) 
        {
            this.minYear = minYear;
        }

        public string IsLeap(int year)
        {
            return IsLeapYear(year) ? "yay" : "nay";
        }

        public bool IsLeapYear(int year)
        {
            if(year <= 0) throw new ArgumentException("ERROR: A year cannot be less than or equal to 0!"); 
            else if(year < minYear) throw new ArgumentException("ERROR: A year cannot be less than '" + minYear + "'!");

            if (year % 4 == 0 && year % 100 != 0) return true;
            else if (year % 400 == 0) return true;
            return false;
        }
    }
}
