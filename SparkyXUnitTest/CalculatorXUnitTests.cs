using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {

        private Calculator _calculator;

        public CalculatorXUnitTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.AddNumbers(10, 20);
            //Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(11, 1)]
        [InlineData(13, 2)]
        public void IsOddNumber_IputOddNumber_ReturnTrue(int a, int b)
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.IsOddNumber(a);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOddNumber_IputEvenNumber_ReturnFalse()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.IsOddNumber(10);
            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddNumber_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            var calc = new Calculator();
            var result = calc.IsOddNumber(a);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(5.4, 10.5)] // 15.9
        [InlineData(5.43, 10.53)] // 15.96
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.AddNumbersDouble(a, b);
            //Assert
            Assert.Equal(15.9, result, 0.5);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            var expectedOddRange = new List<int>() { 5, 7, 9 };

            var result = _calculator.GetOddRange(5, 10);

            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u).ToList(), result);
            //Assert.That(result, Is.Unique);
        }
    }
}