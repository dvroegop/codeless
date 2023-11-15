using FluentAssertions;

namespace CSharpCalculator.Tests
{
    public class AwesomeCalculatorShould
    {
        [Fact]
        public void BeCreateable()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();

            // Assert
            sut.Should().NotBeNull("we just created an instance.");
        }

        [Theory]
        [InlineData("")]
        [InlineData("1,2")]
        [InlineData("1")]
        public void Add(string num)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            int result = sut.Add(num);

            // Assert
            Assert.True(result >= 0);
        }
    }
}