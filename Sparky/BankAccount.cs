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
            _balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}
