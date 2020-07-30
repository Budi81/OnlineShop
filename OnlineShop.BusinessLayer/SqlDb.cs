using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineShop.BusinessLayer
{
    class SqlDb : IDatabase
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=OnlineShopDb;Trusted_Connection = True;";

        public void AddCustomer(Dictionary<string, string> customerData)
        {
            string addCustomerCommand = $@"INSERT INTO [dbo].[Customers] values (null, {customerData["FirstName"]}, {customerData["LastName"]}, {customerData["Adress"]}, {customerData["Email"]}, {customerData["Password"]})";
            
            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(addCustomerCommand, dbConnection);

            dbConnection.Open();

            command.BeginExecuteNonQuery();

            dbConnection.Dispose();
        }

        public void AddOrder(Order order)
        {
            string addOrderCommand = $@"INSERT INTO [dbo].[Orders] values ({order.OrderId1}, {order.Customer.CustomerId}, {order.OrderCount}, {order.DateOfOrder}, {order.IsSend}"
                + "SELECT CAST(scope_identity() AS int)";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(addOrderCommand, dbConnection);

            dbConnection.Open();

            int newId = (int)command.ExecuteScalar();
            // jeszcze nie mam pomysłu jak to dokończyć. Musi do tabeli OrderProduct dopisać Id nowego Order oraz id Produktów z tego ordera
            string addOrderProduct = $@"INSERT INTO [dbo].[OrderProduct] values ({0}, {newId}, {order.Products.Keys})";

            SqlCommand command2 = new SqlCommand(addOrderProduct, dbConnection);

            command2.ExecuteNonQuery();

            dbConnection.Dispose();
        }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }

        public void DelateCustomer(Customer customer)
        {
            string delateCustomer = $@"DELETE FROM [dbo].[Customers] WHERE CustomerId ={customer.CustomerId}";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(delateCustomer, dbConnection);

            dbConnection.Open();

            command.ExecuteNonQuery();

            dbConnection.Dispose();
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
            string getAllCustomers = @"SELECT CustomerId, FirstName, LastName, Adress, Email, Password FROM [dbo].[Customers]";
            
            List<Customer> customers = new List<Customer>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getAllCustomers, dbConnection);

            dbConnection.Open();
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), 
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

                customers.Add(customer);
            }
            reader.Close();
            dbConnection.Dispose();

            return customers;
        }
        
        public List<Order> GetAllOrders()
        {
            string getAllOrders = @"SELECT id, CustomerId, AmountToPay, DateOfOrder, Status FROM [dbo].[Orders]";
            
            List<Order> orders = new List<Order>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getAllOrders, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
             // jeszcze mysłę jak to zrobić żeby zaciągało różne dane z różnych tabel potrzebne do utworzenia instancji Order
            while (reader.Read())
            {
                Order order = new Order(reader[1], reader[2], Convert.ToDecimal(reader[3]), reader[4], Convert.ToBoolean(reader[5]));

                orders.Add(order);
            }
            reader.Close();
            dbConnection.Dispose();

            return orders;
        }

        public List<Product> GetAllProducts()
        {
            string getAllProducts = @"SELECT ProductId, ProductName, ProductPrice, Stock from [dbo].[Products]";
            
            List<Product> products = new List<Product>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getAllProducts, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            // nie wiem jak zrobić listę<Product> bez tworzenia instancji poszczególnych produktów
            while (reader.Read())
            {
                Product product = new Product(reader[0], reader[1].ToString(), Convert.ToDecimal(reader[2]), reader[4].ToString());
            }
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
