namespace Sparky
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        public double GetPrice(ICustomer customer) 
        {
            return customer.IsPlatinum ? Price * 0.8 : Price;
        }
    }
}
