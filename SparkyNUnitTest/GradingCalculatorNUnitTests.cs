using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void Grade_InputScoreAndAttendance_ReturnsA()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.AreEqual("A", result);
        }

        [Test]
        public void Grade_InputScoreAndAttendance_ReturnsB()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.AreEqual("B", result);
        }

        [Test]
        public void Grade_InputScoreAndAttendance_ReturnsC()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();
            Assert.AreEqual("C", result);
        }

        [Test]
        public void Grade_InputScoreAndLowAttendance_ReturnsB()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;

            string result = _gradingCalculator.GetGrade();
            Assert.AreEqual("B", result);
        }

        [Test]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string Grade_InputScoreAndAttendance_ReturnsF(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            return _gradingCalculator.GetGrade();
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string Grade_InputScoreAndAttendance_ReturnsGrade(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            return _gradingCalculator.GetGrade();
        }
    }
}
