using System;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class Shop
    {
        bool isRunning = true;
        private string userLogin = null;
        private string userPassword = null;

        private IDatabase database;

        private IController controller;

        public Shop(IDatabase database, IController controller)
        {
            this.database = database;
            this.controller = controller;
        }

        private int DisplayStartingMenu()
        {
            int userChoice = controller.UserChoice(
                "Welcome to E-Shop!\n" +
                "What do you want to do?\n" +
                "  (1) Login\n" +
                "  (2) Sign in\n" +
                "  (3) Exit");
            return userChoice;
        }

        private void UserLogin()
        {
            userLogin = controller.GetInput("Login: ");
            userPassword = controller.GetPassword();
        }
        public bool IsEmployee()
        {
            return (userLogin == Employee.Login && userPassword == Employee.Password);
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
            int id = 0;
            string name = controller.GetInput("Name: ");
            string surname = controller.GetInput("Surname: ");
            string address = controller.GetInput("Address: ");
            string email = controller.GetInput("E-mail: ");
            userLogin = email;
            string password = controller.GetPassword();

            Customer newCustomer = new Customer(id, name, surname, address, email, password);
            database.AddCustomer(newCustomer);
        }

        public void ProgramRunning()
        {
            while (isRunning)
            {
                int userChoice = DisplayStartingMenu();
                bool errorDisplayed = false;
                userLogin = null;
                userPassword = null;

                switch (userChoice)
                {
                    case 1:
                        UserLogin();
                        break;
                    case 2:
                        CreateAccount();
                        break;
                    case 3:
                        controller.ProgramExit();
                        break;
                    default:
                        controller.DisplayError("Wrong choice!", 1000);
                        errorDisplayed = true;
                        break;
                }

                if (errorDisplayed)
                {
                    continue;
                }

                if (IsEmployee())
                {
                    do
                    {
                        errorDisplayed = false;
                        switch (controller.UserChoice(
                            "Hi Mark!" +
                            "What do you want to do today?\n" +
                            "  (1) Show all orders\n" +
                            "  (2) ..."))
                        {
                            case 1:
                                ShowAllOrders();
                                break;
                            case 2:
                                
                                break;

                            default:
                                controller.DisplayError("Wrong choice!", 1000);
                                errorDisplayed = true;
                                break;
                        }
                    } while (errorDisplayed);

                }
                else
                {
                    do
                    {
                        errorDisplayed = false;
                        switch (controller.UserChoice(
                            $"Hello {userLogin}!\n" +
                            $"How may I help you?\n" +
                            $"  (1) ..."))
                        {
                            case 1:

                                break;
                            default:
                                controller.DisplayError("Wrong choice!", 1000);
                                errorDisplayed = true;
                                break;
                        }
                    } while (errorDisplayed);

                }
            }
        }

    }
}
