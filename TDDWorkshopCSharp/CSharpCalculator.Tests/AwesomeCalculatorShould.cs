using FluentAssertions;
using Moq;
using System.Net;
using Xunit.Sdk;

namespace CSharpCalculator.Tests
{
    public class AwesomeCalculatorShould
    {
        [Fact]
        public void BeCreateable()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("");
            // Act
            sut = new Calculator(inputService);

            // Assert
            sut.Should().NotBeNull("we just created an instance.");
        }


        [Fact]
        public void Return_0_If_Empty_String_Is_Passed()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("");

            // Act
            sut = new Calculator(inputService);
            var result = sut.Add();

            // Assert
            result.Should().Be(0);
        }


        [Fact]
        public void Return_Integer_Value_If_String_Has_Single_Integer()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("1");

            // Act
            sut = new Calculator(inputService);
            var result = sut.Add();

            // Assert
            result.Should().Be(1);
        }


        [Fact]
        public void Return_Sum_Of_The_Passed_Values()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("1,2");

            // Act
            sut = new Calculator(inputService);
            var result = sut.Add();

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Throw_Unsupported_Arguments()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("abc");

            // Act
            sut = new Calculator(inputService);
            // Assert
            Assert.Throws<UnSupportedArgumentsException>(() => sut.Add());
        }

        [Fact]
        public void Return_Sum_Of_The_Passed_More_Than_Two_Values()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("1,2,3,4,5");

            // Act
            sut = new Calculator(inputService);
            var result = sut.Add();

            // Assert
            result.Should().Be(15);
        }
        [Fact]
        public void Return_Sum_Of_The_Passed_More_Than_Two_Values_And_Invalid_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService("1,2,3,a");

            // Act
            sut = new Calculator(inputService);

            // Assert
            Assert.Throws<UnSupportedArgumentsException>(() => { sut.Add(); });
        }
        [Fact]
        public void Throw_Over_Flow_Exception_If_Result_Becomes_Greater_Than_Max_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService($"{int.MaxValue},1");

            // Act
            sut = new Calculator(inputService);

            // Assert
            Assert.Throws<OverflowException>(() => { sut.Add(); });
        }
        [Fact]
        public void Throw_Over_Flow_Exception_If_Result_Becomes_Less_Than_Min_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            IInputService inputService = MockInputService($"{int.MinValue},-11");

            // Act
            sut = new Calculator(inputService); ;

            // Assert
            Assert.Throws<OverflowException>(() => { sut.Add(); });
        }
        [Fact]
        public void Throw_WebException_When_Retries_Count_Exceeds()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            Mock<IInputService> inputService = new Mock<IInputService>();
            inputService.Setup(x => x.GetInput()).Throws<WebException>();

            // Act
            sut = new Calculator(inputService.Object);

            // Assert
            Assert.Throws<WebException>(() => { sut.Add(); });
        }
        [Fact]
        public void Add_When_Retries_Count_Less_Than_Max_Limit()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;
            Mock<IInputService> inputService = new Mock<IInputService>();
            inputService.SetupSequence(x => x.GetInput())
                .Throws<WebException>()
                .Throws<WebException>()
                .Returns("12");

            // Act
            sut = new Calculator(inputService.Object);
            var sum = sut.Add();

            // Assert
            sum.Should().Be(12);
        }

        private IInputService MockInputService(string input)
        {
            Mock<IInputService> inputService = new Mock<IInputService>();
            inputService.Setup(x => x.GetInput()).Returns(input);

            return inputService.Object;
        }
    }
}