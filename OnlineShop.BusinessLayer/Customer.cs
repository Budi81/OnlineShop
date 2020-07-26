using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class Customer
    {
        int CustomerId;

        string name;
        string surname;
        string adress;
        string email;
        string login;
        string password;

        ShoppingCart chart;

        void UdateData(Dictionary<string, string> customerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
