﻿using System.Collections.Generic;

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

        List<Customer> GetCustomers(string name, string surname);

        Customer GetCustomer(int customerId);

        Customer GetCustomer(string email, string password);

        Order GetOrder(string orderId);

        List<Product> GetProduct(string productName);

        Product GetProduct(int productId);

        List<Order> GetCustomerOrders(Customer customer);
    }
}