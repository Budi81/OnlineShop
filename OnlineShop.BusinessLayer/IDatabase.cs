using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public interface IDatabase
    {
         void AddCustomer(Customer customer);

         Order AddOrder(Order order);

         Product AddProduct(Product product);

         void DeleteCustomer(Customer customer);

         void DeleteOrder(Order order);

         List<Customer> GetAllCustomers();

         List<Order> GetAllOrders();

         List<Product> GetAllProducts();

         List<Customer> GetCustomer(string name, string surname);

         Customer GetCustomer(int customerId);

         Order GetOrder(string orderId);

         List<Product> GetProduct(string productName);

         Product GetProduct(int productId);


    }
}
