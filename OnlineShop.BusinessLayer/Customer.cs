namespace OnlineShop.BusinessLayer
{
    public class Customer
    {
        private readonly int Id;

        private string name;
        private string surname;
        private string address;
        private string email;
        private string password;

        private ShoppingCart chart;

        public Customer(int customerId, string name, string surname, string address, string email, string password)
        {
            this.Id = customerId;
            Name = name;
            Surname = surname;
            Address = address;
            Email = email;
            Password = password;
            Chart = new ShoppingCart();
        }

        public string Name { get => name; private set => name = value; }
        public string Surname { get => surname; private set => surname = value; }
        public string Address { get => address; private set => address = value; }
        public string Email { get => email; private set => email = value; }
        public string Password { get => password; set => password = value; }

        public ShoppingCart Chart { get => chart; private set => chart = value; }

        public int CustomerId => Id;

        public void ModifyName(string name)
        {
            this.Name = name;
        }

        public void ModifySurname(string surname)
        {
            this.Surname = surname;
        }

        public void ModifyAddress(string address)
        {
            this.Address = address;
        }

        public void ModifyEmail(string email)
        {
            this.Email = email;
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }
    }
}