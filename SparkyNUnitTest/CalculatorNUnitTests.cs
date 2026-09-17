using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.AddNumbers(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        [TestCase(11, 1)]
        [TestCase(13, 2)]
        public void IsOddNumber_IputOddNumber_ReturnTrue(int a, int b)
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.IsOddNumber(a);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOddNumber_IputEvenNumber_ReturnFalse()
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.IsOddNumber(10);
            //Assert
            Assert.That(result, Is.EqualTo(false));
        }
    }
}