using System;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class Shop
    {
        bool isRunning = true;

        private IDatabase database;

        private IController controller;

        public Shop(IDatabase database, IController controller)
        {
            this.database = database;
            this.controller = controller;
        }

        private void DisplayStartingMenu()
        {
            throw new NotImplementedException();
        }

        public bool IsEmployee()
        {
            throw new NotImplementedException();
        }

        private void ShowAllProducts()
        {
            List<Product> products = database.GetAllProducts();
            foreach (var product in products)
            {
                controller.WriteOutData(
                    $"ID: {product.ProductId}, Type: {product.Type}, " +
                    $"Name: {product.ProductName}, Price: {product.Price}, " +
                    $"In stock: {product.Stock}");
            }
        }

        private void ShowProduct(string productName)
        {
            List<Product> products = database.GetProduct(productName);
            Product product = products[0];
            controller.WriteOutData(
                $"ID: {product.ProductId}, Type: {product.Type}, " +
                $"Name: {product.ProductName}, Price: {product.Price}, " +
                $"In stock: {product.Stock}");
        }

        private void ShowAllCustomers()
        {
            List<Customer> allCustomers = database.GetAllCustomers();
            foreach (var customer in allCustomers)
            {
                controller.WriteOutData(
                    $"ID: {customer.CustomerId}, {customer.Name} {customer.Surname}\n" +
                    $"e-mail: {customer.Email}");
            }
        }

        private void ShowCustomer(int customerId)
        {
            Customer customer = database.GetCustomer(customerId);
            controller.WriteOutData(
                $"ID: {customer.CustomerId}, {customer.Name} {customer.Surname}\n" +
                $"e-mail: {customer.Email}");
        }

        private void ShowAllOrders()
        {
            List<Order> orders = database.GetAllOrders();
            foreach (var order in orders)
            {
                controller.WriteOutData(
                    $"ID: {order.OrderId}, Date: {order.DateOfOrder}, " +
                    $"Product: {order.Products}, Count: {order.OrderCount}, " +
                    $"Customer: {order.Customer}, Sent: {order.IsSend}");
            }
        }

        private void FindOrder(string orderId)
        {
            Order order = database.GetOrder(orderId);
            controller.WriteOutData(
                $"ID: {order.OrderId}, Date: {order.DateOfOrder}, " +
                $"Product: {order.Products}, Count: {order.OrderCount}, " +
                $"Customer: {order.Customer}, Sent: {order.IsSend}");
        }

        private void CreateAccount()
        {
            throw new NotImplementedException();
        }

        public void ProgramRunning()
        {
            while (isRunning)
            {
                DisplayStartingMenu();

                if (IsEmployee())
                {
                    switch (controller.UserChoice())
                    {
                        case 1:
                            ShowAllOrders();
                            
                            break;
                        case 2:
                            

                            break;

                        default:
                            controller.DisplayError("Wrong choice!", 1000);

                            break;
                    }

                }
                else
                {
                    switch (controller.UserChoice())
                    {
                        case 1:

                            break;
                        default:
                            controller.DisplayError("Wrong choice!", 1000);

                            break;
                    }

                }
            }
        }

    }
}
