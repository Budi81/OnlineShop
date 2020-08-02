namespace OnlineShop.BusinessLayer
{
    public class ProductAttribute
    {
        private string name;

        private string value;

        public ProductAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get => name; private set => name = value; }

        public string Value { get => value; private set => this.value = value; }
    }
}