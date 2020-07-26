using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineShop.BusinessLayer
{
    class SqlDb : IDatabase
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=CarsDatabase;Trusted_Connection = True;";
        private string querryGetAllOrders = @"SELECT * from";

        public void AddCustomer()
        {
            throw new NotImplementedException();
        }

        public void AddOrder()
        {
            throw new NotImplementedException();
        }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public void DelateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DelateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DelateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(querryGetAllOrders, dbConnection);

            dbConnection.Open();
            
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
