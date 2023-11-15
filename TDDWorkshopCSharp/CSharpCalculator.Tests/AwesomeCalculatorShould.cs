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

        [Fact]
        public void ReturnZeroIfEmptyString()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
         
            // Act
            sut = new Calculator();

            int value = sut.Add(string.Empty);

            // Assert
            value.Should().Be(0);
        }

        [Fact]
        public void ThrowsIfNullString()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();

            Action act = () => sut.Add(null);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("whatever");
        }
    }
}