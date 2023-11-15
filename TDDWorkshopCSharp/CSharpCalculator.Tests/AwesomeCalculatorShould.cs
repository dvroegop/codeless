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
    }
}