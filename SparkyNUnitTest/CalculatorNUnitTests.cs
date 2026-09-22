using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {

        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

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

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
        {
            var calc = new Calculator();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            var calc = new Calculator();
            //Act
            var result = calc.AddNumbersDouble(a, b);
            //Assert
            Assert.AreEqual(15.9, result, 0.5);
            Assert.That(15.9, Is.EqualTo(result).Within(0.5));
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnValidOddNumberRange()
        {
            var expectedOddRange = new List<int>() { 7, 5, 9 };

            var result = _calculator.GetOddRange(5, 10);

            Assert.That(result, Is.EquivalentTo(expectedOddRange));

           //Assert.That(result, Is.EqualTo(expectedOddRange));      // FAIL
            Assert.That(result, Is.EquivalentTo(expectedOddRange)); // PASS
            //Assert.Contains(7, expectedOddRange); // PASS
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result.OrderByDescending(x => x).ToList(), Is.Ordered.Descending);

            Assert.That(result, Is.Unique);
        }
    }
}