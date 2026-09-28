namespace Sparky
{

    public interface ILogBook
    {
        int LogSeverity { get; set; }
        string LogType { get; set; }
        void Message(string message);

        bool LogToDb(string message);

        bool LogBalanceAterWithdrawal(int balanceAfterWithdrawal);

        string MessageWithReturnStr(string message);
        bool LogWithOutputResult(string str, out string OutputStr);
        bool LogWithRefObj(ref Customer customer);
    }

    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; } = string.Empty;

        public bool LogBalanceAterWithdrawal(int balanceAfterWithdrawal)
        {
            if(balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string str, out string OutputStr)
        {
            OutputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

    }
}
