using System;
using System.IO;
using Xunit;

namespace LeapYear.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(0, false)]
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
            Assert.Equal(expected, Program.IsLeapYear(year));
        }

        [Theory]
        [InlineData(0, false)]
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
            Assert.Equal(expected, Program.IsLeapYear(year));
        }

        [Theory]
        [InlineData(0, false)]
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
            Assert.Equal(expected, Program.IsLeapYear(year));
        }

        [Theory]
        [InlineData(0, "nay")]
        [InlineData(1, "nay")]
        [InlineData(2, "nay")]
        [InlineData(3, "nay")]
        [InlineData(4, "yay")]
        [InlineData(5, "nay")]
        [InlineData(6, "nay")]
        [InlineData(7, "nay")]
        [InlineData(8, "yay")]
        [InlineData(9, "nay")]
        [InlineData(10, "nay")]
        [InlineData(100, "nay")]
        [InlineData(104, "yay")]
        [InlineData(200, "nay")]
        [InlineData(300, "nay")]
        [InlineData(400, "yay")]
        [InlineData(401, "nay")]
        [InlineData(404, "yay")]
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
    }
}
