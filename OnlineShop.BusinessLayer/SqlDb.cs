using OnlineShop.BusinessLayer.Enums;
using OnlineShop.BusinessLayer.Products;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnlineShop.BusinessLayer
{
    public class SqlDb : IDatabase
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=OnlineShopDb;Trusted_Connection = True;";

        public void AddCustomer(Customer customer)
        {
            string addCustomerCommand = $@"INSERT INTO [dbo].[Customers] (FirstName, LastName, Adress, Email, password) values ('{customer.Name}', '{customer.Surname}', '{customer.Address}', '{customer.Email}', '{customer.Password}')";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(addCustomerCommand, dbConnection);

            dbConnection.Open();

            command.ExecuteNonQuery();

            dbConnection.Dispose();
        }

        public Order AddOrder(Order order)
        {
            string addOrderCommand = "INSERT INTO [dbo].[Orders] (CustomerId, AmountToPay, DateOfOrder, Status) "
                + $@"values ('{order.Customer.CustomerId}', '{order.OrderCount}', '{order.DateOfOrder}', '{order.IsSend}'); "
                + "SELECT CAST(scope_identity() AS int)";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(addOrderCommand, dbConnection);

            dbConnection.Open();

            int newId = (int)command.ExecuteScalar();

            order = order.WithId(newId);

            foreach (KeyValuePair<Product, int> keyValues in order.Products)
            {
                string addOrderProduct = $@"INSERT INTO [dbo].[OrderProduct] (OrderId, ProductId, Count) "
                    + $@"values ('{order.OrderId}', '{keyValues.Key.ProductId}', '{keyValues.Value}'; "
                    + "SELECT CAST(scope_identity() AS int)";

                SqlCommand command2 = new SqlCommand(addOrderProduct, dbConnection);

                command2.ExecuteNonQuery();
            }
            dbConnection.Dispose();

            return order;
        }

        public Product AddProduct(Product product)
        {
            string addProduct = $@"INSERT INTO [dbo].[Products] (ProductName, ProductPrice, Stock) "
                + $@"values ('{product.ProductName}', '{product.Price}', '{product.Stock}')";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(addProduct, dbConnection);

            dbConnection.Open();

            int newId = (int)command.ExecuteScalar();

            product = product.WithId(newId);

            dbConnection.Close();

            return product;
        }

        public void DeleteCustomer(Customer customer)
        {
            string deleteCustomer = $@"DELETE FROM [dbo].[Customers] WHERE CustomerId ='{customer.CustomerId}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(deleteCustomer, dbConnection);

            dbConnection.Open();

            command.ExecuteNonQuery();

            dbConnection.Dispose();
        }

        public void DeleteOrder(Order order)
        {
            string deleteOrder = $@"DELETE FROM [dbo].[Orders] WHERE id ='{order.OrderId}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(deleteOrder, dbConnection);

            dbConnection.Open();

            command.ExecuteNonQuery();

            string deleteOrderProduct = $@"DELETE FROM [dbo].[OrderProduct] WHERE OrderId ='{order.OrderId}'";

            SqlCommand command2 = new SqlCommand(deleteOrderProduct, dbConnection);

            command2.ExecuteNonQuery();

            dbConnection.Dispose();
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
            while (reader.Read())
            {
                Dictionary<Product, int> orderProducts = GetOrderProducts(Convert.ToInt32(reader[0]));

                Customer customer = GetCustomer(Convert.ToInt32(reader[1]));

                Order order = new Order(Convert.ToInt32(reader[0]), customer, Convert.ToDecimal(reader[2]), orderProducts, Convert.ToDateTime(reader[3]), Convert.ToBoolean(reader[4]));

                orders.Add(order);
            }
            reader.Close();
            dbConnection.Dispose();

            return orders;
        }

        public List<Product> GetAllProducts()
        {
            string getAllProducts = @"SELECT ProductId, ProductName, ProductPrice, Stock, Type from [dbo].[Products]";

            List<Product> products = new List<Product>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getAllProducts, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dictionary<String, String> productAttributes = GetProductAttributes(Convert.ToInt32(reader[0]));
                Product product = ProductFactory.Produce(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDecimal(reader[2]), Convert.ToInt32(reader[3]), (ProductType)Enum.Parse(typeof(ProductType), reader[4].ToString()), productAttributes);

                products.Add(product);
            }

            return products;
        }
        
        public List<Customer> GetCustomers(string name, string surname)
        {
            string getCustomer = $@"SELECT CustomerId, FirstName, LastName, Adress, Email, Password "
                +$@"FROM [dbo].[Customers] WHERE FirstName='{name}' and LastName='{surname}'";

            List<Customer> customers = new List<Customer>();
            
            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getCustomer, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Customer customer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                customers.Add(customer);
            }
            reader.Close();
            dbConnection.Close();

            return customers;

        }

        public Customer GetCustomer(int customerId)
        {
            string getCustomer = $@"SELECT CustomerId, FirstName, LastName, Adress, Email, Password "
                +$@"FROM [dbo].[Customers] WHERE CustomerId='{customerId}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getCustomer, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Customer customer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), 
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

            reader.Close();
            dbConnection.Close();

            return customer;
        }

        public Customer GetCustomer(string email, string password)
        {
            string getCustomer = $@"SELECT CustomerId, FirstName, LastName, Adress, Email, Password "
                +$@"FROM [dbo].[Customers] WHERE Email='{email}' and Password='{password}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getCustomer, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Customer customer = new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), 
                reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

            reader.Close();
            dbConnection.Close();

            return customer;

        }
        
        public Order GetOrder(string orderId)
        {
            string getCustomer = $@"SELECT id, CustomerId, AmountToPay, DateOfOrder, Status FROM [dbo].[Orders] WHERE id='{orderId}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getCustomer, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Dictionary<Product, int> orderProducts = GetOrderProducts(Convert.ToInt32(reader[0]));

            Customer customer = GetCustomer(Convert.ToInt32(reader[1]));

            Order order = new Order(Convert.ToInt32(reader[0]), customer, Convert.ToDecimal(reader[2]), 
                orderProducts, Convert.ToDateTime(reader[3]), Convert.ToBoolean(reader[4]));

            reader.Close();
            dbConnection.Close();

            return order;
        }

        public List<Product> GetProduct(string productName)


        {
            string getProducts = $@"SELECT ProductId, ProductName, ProductPrice, Stock, Type "
                +$@"FROM [dbo].[Products] WHERE ProductName LIKE '{productName}'";

            List<Product> products = new List<Product>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getProducts, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dictionary<String, String> productAttributes = GetProductAttributes(Convert.ToInt32(reader[0]));
                Product product = ProductFactory.Produce(Convert.ToInt32(reader[0]), reader[1].ToString(), 
                    Convert.ToDecimal(reader[2]), Convert.ToInt32(reader[3]), (ProductType)Enum.Parse(typeof(ProductType), 
                    reader[4].ToString()), productAttributes);

                products.Add(product);
            }

            return products;

        }

        public Product GetProduct(int productId)
        {
            string getProduct = $@"SELECT ProductId, ProductName, ProductPrice, Stock, Type FROM [dbo].[Products] WHERE ProductId='{productId}'";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getProduct, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Product product = null;

   
            Dictionary<String, String> productAttributes = GetProductAttributes(Convert.ToInt32(reader[0]));
            product = ProductFactory.Produce(Convert.ToInt32(reader[0]), reader[1].ToString(), 
                Convert.ToDecimal(reader[2]), Convert.ToInt32(reader[3]), (ProductType)Enum.Parse(typeof(ProductType), 
                reader[4].ToString()), productAttributes);
     
            reader.Close();
            dbConnection.Close();

            return product;

        }

        private Dictionary<Product, int> GetOrderProducts(int orderId)
        {
            string getOrderProducts = $@"SELECT Id, ProductId, Count FROM [dbo].[OrderProduct] WHERE OrderId='{orderId}'";

            Dictionary<Product, int> orderProducts = new Dictionary<Product, int>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getOrderProducts, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = GetProduct(Convert.ToInt32(reader[1]));

                orderProducts.Add(product, Convert.ToInt32(reader[0]));
            }
            reader.Close();
            dbConnection.Dispose();

            return orderProducts;
        }

        private Dictionary<String, String> GetProductAttributes(int productId)
        {
            string getOrderProducts = $@"SELECT Name, Value FROM [dbo].[ProductAttributes] WHERE ProductId='{productId}'";

            Dictionary<String, String> productAttributes = new Dictionary<String, String>();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(getOrderProducts, dbConnection);

            dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                productAttributes.Add(reader[0].ToString(), reader[1].ToString());
            }
            reader.Close();
            dbConnection.Dispose();

            return productAttributes;
        }
    }  
}

