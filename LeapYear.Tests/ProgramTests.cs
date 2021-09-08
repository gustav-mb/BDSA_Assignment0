using System;
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
        public void Leap_Year_Check(int year, bool expected)
        {
            Assert.Equal(expected, Program.IsLeapYear(year));
        }
    }
}
