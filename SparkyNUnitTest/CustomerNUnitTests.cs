using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {

        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            var fullName = _customer.GreetAndCombineNames("Ben", "Spark");

            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark!"));
            Assert.AreEqual(fullName, "Hello, Ben Spark!");

            Assert.That(fullName, Does.Contain("Hello"));
            Assert.That(fullName, Does.EndWith("Spark!"));
            Assert.That(fullName, Does.Contain("hello").IgnoreCase);

            Assert.That(fullName, Does.Match("Hello, [A-Z][a-z]+ [A-Z][a-z]+!"));
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
           // var fullName = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.IsNull(_customer.GreetMessage);
            Assert.That(_customer.GreetMessage, Is.Null);
        }
    }
}
