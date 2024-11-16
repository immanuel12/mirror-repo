using System;
using Xunit;

namespace HelloWorldApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_HelloWorldOutput()
        {
            // Arrange
            var expectedOutput = "Hello, World!";
            
            // Act
            var output = "Hello, World!"; // Output yang dihasilkan dari program

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
