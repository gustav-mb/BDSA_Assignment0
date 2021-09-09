using System;
using System.IO;
using Xunit;

namespace LeapYear.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        public void Leap_Year_Check_Divisible_By_Four_Rule(int year, bool expected)
        {
            LeapYearChecker checker = new LeapYearChecker(-1);
            Assert.Equal(expected, checker.IsLeapYear(year));
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        [InlineData(100, false)]
        [InlineData(104, true)]
        [InlineData(108, true)]
        [InlineData(200, false)]
        [InlineData(300, false)]
        public void Leap_Year_Check_Divisible_By_Four_Except_Years_Divisible_By_Hundred(int year, bool expected)
        {
            LeapYearChecker checker = new LeapYearChecker(-1);
            Assert.Equal(expected, checker.IsLeapYear(year));
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        [InlineData(100, false)]
        [InlineData(104, true)]
        [InlineData(200, false)]
        [InlineData(300, false)]
        [InlineData(400, true)]
        [InlineData(401, false)]
        [InlineData(404, true)]
        [InlineData(1600, true)]
        [InlineData(1700, false)]
        [InlineData(1800, false)]
        [InlineData(1900, false)]
        [InlineData(2000, true)]
        public void Leap_Year_Check_All_Rules(int year, bool expected)
        {
            LeapYearChecker checker = new LeapYearChecker(-1);
            Assert.Equal(expected, checker.IsLeapYear(year));
        }

        [Theory]
        [InlineData(1600, "yay")]
        [InlineData(1700, "nay")]
        [InlineData(1800, "nay")]
        [InlineData(1900, "nay")]
        [InlineData(2000, "yay")]
        public void Leap_Year_Check_With_User_Input(int year, string expected)
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader(year.ToString()));

            // Act
            Program.Main(new string[0]);

            // Assert
            string[] output = writer.ToString().Split(Environment.NewLine);
            Assert.Equal(expected, output[2].Trim());
        }

        [Theory]
        [InlineData(1852, 0, "ERROR: A year cannot be less than or equal to 0!")]
        [InlineData(1852, -1, "ERROR: A year cannot be less than or equal to 0!")]
        [InlineData(1852, 1851, "ERROR: A year cannot be less than '1852'!")]
        public void Leap_Year_Input_Invalid_Year_Throws_Argument_Exception(int minYear, int year, string message) 
        {
            var checker = new LeapYearChecker(minYear);
            Action a = () => checker.IsLeap(year);

            var exception = Assert.Throws<ArgumentException>(a);
            Assert.Equal(message, exception.Message);
        }

        [Theory]
        [InlineData("A", "ERROR: Only numbers are accepted!")]
        [InlineData("Eighteen fifty two", "ERROR: Only numbers are accepted!")]
        [InlineData("1853", "nay")]
        public void Leap_Year_User_Inputs_Character_Throws_Format_Exception(string input, string expected) 
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader(input));

            // Act
            Program.Main(new string[0]);

            // Assert
            string[] output = writer.ToString().Split(Environment.NewLine);
            Assert.Equal(expected, output[2].Trim());
        }
    }
}
