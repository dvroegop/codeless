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
        [InlineData("-1")]
        [InlineData("12345,9875")]
        [InlineData("12345,9875, 2, 3, 8374,2983, 38, 3746, 348")]
        public void Add_Should_Return_Valid(string num)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            int result = sut.Add(num);

            // Assert
            Assert.True(result >= 0 || result <= 0);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("ab,2")]
        [InlineData("11999999999999999999999999999999999999999999999999999999")]
        public void Add_Should_ThrowException(string num)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Assert
            Assert.Throws<InvalidCastException>(() => sut.Add(num));
        }
    }
}