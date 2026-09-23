
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTests
    {

        private Fibo _fibo;

        [SetUp]
        public void Setup()
        {
            _fibo = new Fibo();
        }

        [Test]
        public void GetFiboSeries_InputRange1_ReturnsCollection()
        {
            _fibo.Range = 1;
            var expectedResult = new List<int> { 0 };
            var result = _fibo.GetFiboSeries();
            
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.EquivalentTo(expectedResult));
            });
        }

        [Test]
        public void GetFiboSeries_InputRange6_ReturnsCollection()
        {
            _fibo.Range = 6;
            var expectedResult = new List<int> { 0, 1, 1, 2, 3, 5 };
            var result = _fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain(3));
                Assert.That(result.Count, Is.EqualTo(6));
                Assert.That(result, Does.Not.Contain(4));
                Assert.That(result, Is.EquivalentTo(expectedResult));
            });
        }
    }
}
