using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {

        private Fibo _fibo;

        public FiboXUnitTests()
        {
            _fibo = new Fibo();
        }

        [Fact]
        public void GetFiboSeries_InputRange1_ReturnsCollection()
        {
            _fibo.Range = 1;
            var expectedResult = new List<int> { 0 };
            var result = _fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.NotEmpty(result);
                Assert.Equal(expectedResult.Order().ToList(), result);
                Assert.True(expectedResult.SequenceEqual(result));
            });
        }

        [Fact]
        public void GetFiboSeries_InputRange6_ReturnsCollection()
        {
            _fibo.Range = 6;
            var expectedResult = new List<int> { 0, 1, 1, 2, 3, 5 };
            var result = _fibo.GetFiboSeries();

            Assert.Multiple(() =>
            {
                Assert.Contains(3, result);
                Assert.Equal(6, result.Count);
                Assert.DoesNotContain(4, result);
                Assert.Equal(expectedResult, result);
            });
        }
    }
}
