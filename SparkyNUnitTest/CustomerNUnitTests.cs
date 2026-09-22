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

            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Hello, Ben Spark!"));
                Assert.AreEqual(fullName, "Hello, Ben Spark!");

                Assert.That(fullName, Does.Contain("Hello"));
                Assert.That(fullName, Does.EndWith("Spark!"));
                Assert.That(fullName, Does.Contain("hello").IgnoreCase);

                Assert.That(fullName, Does.Match("Hello, [A-Z][a-z]+ [A-Z][a-z]+!"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
           // var fullName = customer.GreetAndCombineNames("Ben", "Spark");
            Assert.IsNull(_customer.GreetMessage);
            Assert.That(_customer.GreetMessage, Is.Null);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = _customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnNotNull()
        {
            _customer.GreetAndCombineNames("Ben", "");

            Assert.IsNotNull(_customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrWhiteSpace(_customer.GreetMessage));  
        }

        [Test]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            Assert.That(() => _customer.GreetAndCombineNames("", "Spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnsPlatinumCustomer()
        {
            _customer.OrderTotal = 150;
            var result = _customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
            Assert.That(result, Is.InstanceOf<CustomerType>());
        }
    }
}
