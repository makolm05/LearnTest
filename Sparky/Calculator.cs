namespace Sparky
{
    public class Calculator
    {

        public List<int> NumberRange = new();

        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }

        public bool IsOddNumber(int a)
        {
            return a % 2 != 0;
        }

        public List<int> GetOddRange(int start, int end)
        {
            NumberRange.Clear();
            for(int i = start; i <= end; i++)
            {
                if (IsOddNumber(i))
                {
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }
}