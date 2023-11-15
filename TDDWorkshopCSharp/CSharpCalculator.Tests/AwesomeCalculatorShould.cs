using FluentAssertions;
using Moq;
using System;

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
        [InlineData("", 0)]
        [InlineData("1,2", 3)]
        [InlineData("1", 1)]
        [InlineData("-1", -1)]
        [InlineData("45,5", 50)]
        [InlineData("2, 2, 3, 100, 200, 300, 400, 500", 1507)]
        public void Add_Should_Return_Valid(string num, int expected)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            int result = sut.Add(num);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("ab,2")]
        public void Add_Should_ThrowInvalidCastException(string num)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            Action act = () => sut.Add(num);

            // Assert
            act.Should().Throw<InvalidCastException>();
        }

        [Fact]
        public void Add_Should_ReturnResult()
        {
            // Arrange
            Calculator sut = new Calculator();
            var dataService = new Mock<IDataService>();
            dataService.Setup(x => x.GetData()).Returns("1,2");

            // Act
            int result = sut.Add(dataService.Object.GetData());

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_Should_PerformRetry()
        {
            // Arrange
            Calculator sut = new Calculator();
            var dataService = new Mock<IDataService>();
            dataService.SetupSequence(x => x.GetData())
                .Returns("")
                .Returns("")
                .Returns("1,2");
            string number = "";
            int count = 0;
            while (count < 3)
            {
                number = dataService.Object.GetData();
                if (!string.IsNullOrEmpty(number))
                {
                    break;
                }
            }
            // Act
            int result = sut.Add(number);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Add_Should_PerformRetryAndFail()
        {
            // Arrange
            Calculator sut = new Calculator();
            var dataService = new Mock<IDataService>();
            dataService.SetupSequence(x => x.GetData())
                .Returns("")
                .Returns("")
                .Returns("")
                .Returns("--");

            string number ="";
            int count = 0;
            while (count < 4)
            {
                number = dataService.Object.GetData();
                if(!string.IsNullOrEmpty(number))
                {
                    break;
                }
            }
            // Act
            Action act = () => sut.Add(number);
            

            // Assert
            act.Should().Throw<InvalidCastException>();
        }
    }
}