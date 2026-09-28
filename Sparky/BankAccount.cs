namespace Sparky
{
    public class BankAccount
    {
        private int _balance { get; set; }
        private readonly ILogBook _logBook;

        public BankAccount(ILogBook logBook)
        {
            _balance = 0;
            _logBook = logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message($"Depositing amount: {amount}");
            _logBook.Message($"Test");
            _logBook.LogSeverity = 101;
            _balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= _balance)
            {
                _logBook.LogToDb($"Withdrawing amount: {amount}");
                _balance -= amount;
                return _logBook.LogBalanceAterWithdrawal(_balance);
            }
            return _logBook.LogBalanceAterWithdrawal(_balance-amount);
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}
