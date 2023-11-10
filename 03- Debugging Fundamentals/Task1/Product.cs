namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        private string Name { get; set; }

        private double Price { get; set; }


        public override bool Equals(object expected)
        {
            if (expected == null || GetType() != expected.GetType())
                return false;

            Product other = (Product)expected;
            return Name == other.Name && Price == other.Price;
        }
    }
}
