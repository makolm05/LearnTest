using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {

        private Customer _customer;

        public CustomerXUnitTests()
        {
            _customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            var fullName = _customer.GreetAndCombineNames("Ben", "Spark");

            Assert.Multiple(
                () => Assert.Equal("Hello, Ben Spark!", fullName),
                () => Assert.Equal("Hello, Ben Spark!", fullName),
                () => Assert.Contains("Hello", fullName),
                () => Assert.EndsWith("Spark!", fullName),
                () => Assert.Contains("hello", fullName, StringComparison.OrdinalIgnoreCase),
                () => Assert.Matches("Hello, [A-Z][a-z]+ [A-Z][a-z]+!", fullName)
            );
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            Assert.Null(_customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = _customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnNotNull()
        {
            _customer.GreetAndCombineNames("Ben", "");

            Assert.NotNull(_customer.GreetMessage);
            Assert.False(string.IsNullOrWhiteSpace(_customer.GreetMessage));
        }

        [Fact]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnsPlatinumCustomer()
        {
            _customer.OrderTotal = 150;
            var result = _customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
