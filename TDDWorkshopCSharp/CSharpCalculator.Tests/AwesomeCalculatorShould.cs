using FluentAssertions;
using Moq;


namespace CSharpCalculator.Tests
{
    public class AwesomeCalculatorShould
    {
        Mock<IService> mockService;
        Calculator sut;

        public AwesomeCalculatorShould()
        {
             mockService = new Mock<IService>();
             sut = new Calculator(mockService.Object);

        }

        [Fact]
        public void BeCreateable()
        {

            sut.Should().NotBeNull("we just created an instance.");
        }

        [Fact]
        public void ReturnZeroIfEmptyString()
        {
            mockService.Setup(p => p.GetInputValue()).Returns(string.Empty);

            int value = sut.Add();

            // Assert
            value.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void ReturnSumOfNumbers(string input, int output)
        {
            mockService.Setup(p => p.GetInputValue()).Returns(input);

            int value = sut.Add();

            // Assert
            value.Should().Be(output);
        }

        [Fact]
        public void ThrowsIfNullString()
        {
            mockService.Setup(p => p.GetInputValue()).Returns(default(string));

            Action act = () => sut.Add();

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'input')");
        }

        [Fact]
        public void ThrowsIfUnSupportedArgument()
        {

            string valueToAdd = "this is not a number";

            mockService.Setup(p => p.GetInputValue()).Returns(valueToAdd);
            Action act = () => sut.Add();

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage("Operation is not valid due to the current state of the object.");
        }

        [Theory]
        [InlineData("2147483647,2147483647,-2147483647,-2147483647", 0)]
        public void ShouldBeZero(string input, int output)
        {
            mockService.Setup(p => p.GetInputValue()).Returns(input);
            int value =  sut.Add();

            // Assert
            value.Should().Be(output);
        }

        [Fact]
        public void ThrowsIfFloatingNumber()
        {
            string valueToAdd = "1.2,1.2,1.2";

            mockService.Setup(p => p.GetInputValue()).Returns(valueToAdd);
          
            Action act = () => sut.Add();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
       
    }
}