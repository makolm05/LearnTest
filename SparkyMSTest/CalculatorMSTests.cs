using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
           //Arrange
           var calc = new Calculator();
            //Act
            var result = calc.AddNumbers(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
