using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class Customer
    {
        private readonly int Id;

        private string name;
        private string surname;
        private string adress;
        private string email;
        private string password;

        private ShoppingCart chart;

        public Customer(int customerId, string name, string surname, string adress, string email, string password)
        {
            this.Id = customerId;
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Password = password;
            Chart = new ShoppingCart();
        }

        public string Name { get => name; private set => name = value; }
        public string Surname { get => surname; private set => surname = value; }
        public string Adress { get => adress; private set => adress = value; }
        public string Email { get => email; private set => email = value; }
        public string Password { get => password; set => password = value; }
        
        public ShoppingCart Chart { get => chart; private set => chart = value; }

        public int CustomerId => Id;

        void UdateData(Dictionary<string, string> customerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
