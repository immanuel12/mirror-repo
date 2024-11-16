using Xunit;
using HelloWorldApp;

namespace HelloWorldApp.Tests
{
    public class HelloWorldTests
    {
        [Fact]
        public void TestHelloWorldOutput()
        {
            // Arrange
            var expectedOutput = "Hello, World!";
            
            // Act
            var output = Program.GetGreeting();  // Panggil metode statis langsung dari Program

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
