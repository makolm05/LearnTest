namespace Sparky
{
    public class Customer
    {
        public string GreetMessage { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            return GreetMessage = $"Hello, {firstName} {lastName}!";
        }
    }
} 
