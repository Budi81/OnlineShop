using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public interface IDatabase
    {
        List<Product> GetAllProducts();

        Product GetProduct(string productName);

        void AddProduct();

        void DelateProduct(Product product);

        List<Customer> GetAllCustomers();

        Customer GetCustomer(string name, string surname);

        void AddCustomer(Dictionary<string, string> customerData);

        void DelateCustomer(Customer customer);

        List<Order> GetAllOrders();

        Order GetOrder(string orderId);

        void AddOrder();

        void DelateOrder(Order order);

    }
}
