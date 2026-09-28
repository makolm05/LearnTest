using Moq;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {

        private BankAccount _bankAccount;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            _bankAccount = new BankAccount(logMock.Object);
            logMock.Setup(x => x.Message(""));

            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(_bankAccount.GetBalance(), Is.EqualTo(100));
        }
        
        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 200)]
        public void Withdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAterWithdrawal(It.Is<int>(x => x >= 0))).Returns(true);


            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(balance);
            var result = _bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);
        }

        [Test]
        public void Withdraw_Withdraw300With200Balance_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogBalanceAterWithdrawal(It.Is<int>(x => x >= 0))).Returns(true);
//            logMock.Setup(x => x.LogBalanceAterWithdrawal(It.Is<int>(x => x < 0))).Returns(false); // by default always false
            logMock.Setup(x => x.LogBalanceAterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(200);
            var result = _bankAccount.Withdraw(300);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDommy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";
            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MessageWithReturnStr("HELLO"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDommy_LogMockString2_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.MessageWithReturnStr("Hi")).Returns((string str) => str.ToLower());
            Assert.IsNull(logMock.Object.MessageWithReturnStr("HELLO"));
        }

        [Test]
        public void BankLogDommy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";
            string result = "";
    
            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDommy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDommy_LogRefChecker2_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref It.Ref<Customer>.IsAny)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDommy_SetAndLogTypeAndSeverityMock_Mock_Test()
        {
            var logMock = new Mock<ILogBook>();
            
            logMock.SetupAllProperties();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("Warning");

            logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10)); 
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

            //callback example
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true)
                .Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            int counter = 5;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true)
                .Callback(() => counter++);

            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            Assert.That(counter, Is.EqualTo(9));
        }

        [Test]
        public void BankLogDommy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(100); 
            Assert.That(_bankAccount.GetBalance(), Is.EqualTo(100));

            //verification
            logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.VerifySet(x => x.LogSeverity = It.IsAny<int>(), Times.Once());
        }
    }
}
 