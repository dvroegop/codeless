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

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void ReturnSumOfNumbers(string input, int output)
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();

            int value = sut.Add(input);

            // Assert
            value.Should().Be(output);
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
            act.Should().Throw<ArgumentNullException>().WithMessage("Null is not valid value");
        }

        [Fact]
        public void ThrowsIfUnSupportedArgument()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            string valueToAdd = "this is not a number";
            // Act
            sut = new Calculator();

            Action act = () => sut.Add(valueToAdd);

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage($"{valueToAdd} is not a numeric value");
        }


    }
}