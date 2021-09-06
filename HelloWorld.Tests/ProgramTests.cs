using System;
using Xunit;
using System.IO;

namespace HelloWorld.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_Print_Hello_World()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Program.Main(new String[0]);

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Equal("Hello, World!", output);
        }
    }
}
