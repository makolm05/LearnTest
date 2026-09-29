using Moq;
using Xunit;

namespace Sparky
{
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20PercentDiscount()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test Product", Price = 50.0 };

            var result = product.GetPrice(new Customer { IsPlatinum = true });

            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20PercentDiscount()
        {
            // Arrange
            var customer = new Mock<ICustomer>();
            customer.Setup(u => u.IsPlatinum).Returns(true);

            var product = new Product { Id = 1, Name = "Test Product", Price = 50.0 };

            var result = product.GetPrice(customer.Object);

            Assert.Equal(40, result);
        }
    }
}