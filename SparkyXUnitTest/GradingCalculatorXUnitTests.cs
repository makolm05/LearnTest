using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator _gradingCalculator;

        public GradingCalculatorXUnitTests()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void Grade_InputScoreAndAttendance_ReturnsA()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.Equal("A", result);
        }

        [Fact]
        public void Grade_InputScoreAndAttendance_ReturnsB()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Fact]
        public void Grade_InputScoreAndAttendance_ReturnsC()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.Equal("C", result);
        }

        [Fact]
        public void Grade_InputScoreAndLowAttendance_ReturnsB()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;

            string result = _gradingCalculator.GetGrade();
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void Grade_InputScoreAndAttendance_ReturnsF(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            Assert.Equal("F", _gradingCalculator.GetGrade());
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void Grade_InputScoreAndAttendance_ReturnsGrade(int score, int attendance, string expectedGrade)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            Assert.Equal(expectedGrade, _gradingCalculator.GetGrade());
        }
    }
}
