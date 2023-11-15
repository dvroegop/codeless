using FluentAssertions;
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

            // Act
            sut = new Calculator();

            // Assert
            sut.Should().NotBeNull("we just created an instance.");
        }


        [Fact]
        public void Return_0_If_Empty_String_Is_Passed()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();
            var result = sut.Add(string.Empty);

            // Assert
            result.Should().Be(0);
        }


        [Fact]
        public void Return_Integer_Value_If_String_Has_Single_Integer()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();
            var result = sut.Add("1");

            // Assert
            result.Should().Be(1);
        }


        [Fact]
        public void Return_Sum_Of_The_Passed_Values()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();
            var result = sut.Add("1,2");

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void Throw_Unsupported_Arguments()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();
            // Assert
            Assert.Throws<UnSupportedArgumentsException>(() => sut.Add("abc"));
        }

        [Fact]
        public void Return_Sum_Of_The_Passed_More_Than_Two_Values()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();
            var result = sut.Add("1,2,3,4,5");

            // Assert
            result.Should().Be(15);
        }
        [Fact]
        public void Return_Sum_Of_The_Passed_More_Than_Two_Values_And_Invalid_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();

            // Assert
            Assert.Throws<UnSupportedArgumentsException>(() => { sut.Add("1,2,3,a"); });
        }
        [Fact]
        public void Throw_Over_Flow_Exception_If_Result_Becomes_Greater_Than_Max_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator();;

            // Assert
            Assert.Throws<OverflowException>(() => { sut.Add($"{int.MaxValue},1"); });
        }
        [Fact]
        public void Throw_Over_Flow_Exception_If_Result_Becomes_Less_Than_Min_Value()
        {

            // Arrange (sut = System Under Test)
            Calculator sut;

            // Act
            sut = new Calculator(); ;

            // Assert
            Assert.Throws<OverflowException>(() => { sut.Add($"{int.MinValue},-11"); });
        }
    }
}