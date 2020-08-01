using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.BusinessLayer
{
    public class Shop
    {
        private bool isRunning = true;
        private bool logIn = false;
        
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
                controller.DisplayCustomer(customer);
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
            string password = controller.GetPassword();

            Customer newCustomer = new Customer(id, name, surname, address, email, password);
            database.AddCustomer(newCustomer);
        }

        private void ShowCustomerOrders(Customer customer)
        {
            List<Order> orders = database.GetCustomerOrders(customer);
            foreach (var order in orders)
            {
                controller.WriteOutData(
                    $"ID: {order.OrderId}, Date: {order.DateOfOrder}, " +
                    $"Product: {order.Products}, Count: {order.OrderCount}, " +
                    $"Sent: {order.IsSend}");
            }
        }

        public void ProgramRunning()
        {
            while (isRunning)
            {
                int userChoice = DisplayStartingMenu();

                switch (userChoice)
                {
                    case 1:
                        UserLogin();
                        break;
                    case 2:
                        CreateAccount();
                        break;
                    case 3:
                        controller.DisplayMessage("Ending program", 1000);
                        isRunning = false;

                        break;
                    default:
                        controller.DisplayMessage("Wrong choice!", 1000);
                        break;
                }

                if (IsEmployee() && isRunning)
                {
                    logIn = true;
                    while (logIn)
                    {
                        switch (controller.UserChoice(
                            "Hi Mark!" +
                            "What do you want to do today?\n" +
                            "  (1) Show all orders\n" +
                            "  (2) Show all customers\n" +
                            "  (3) Show all products\n" +
                            "  (4) Logout"))
                        {
                            case 1:
                                ShowAllOrders();

                                break;
                            case 2:
                                ShowAllCustomers();

                                break;
                            case 3:
                                ShowAllProducts();

                                break;
                            case 4:
                                controller.DisplayMessage("Logging out..", 1000);
                                logIn = false;

                                break;
                            default:
                                controller.DisplayMessage("Wrong choice!", 1000);

                                break;
                        }
                    }
                }
                else if (database.GetCustomer(userLogin, userPassword).IsFound && isRunning)
                {
                    logIn = true;
                    Customer customer = database.GetCustomer(userLogin, userPassword).FoundEntry;

                    while (logIn)
                    {
                        switch (controller.UserChoice(
                            $"Hello {customer.Name}!\n" +
                            $"How may I help you?\n" +
                            "  (1) Go Shopping\n" +
                            "  (2) Show my order\n" +
                            "  (3) Logout"))
                        {
                            case 1:
                                ShowAllProducts();

                                break;
                            case 2:
                                ShowCustomerOrders(customer);

                                break;
                            case 3:
                                controller.DisplayMessage("Logging out..", 1000);
                                logIn = false;

                                break;
                            default:
                                controller.DisplayMessage("Wrong choice!", 1000);

                                break;
                        }
                    }
                }
                else if (!database.GetCustomer(userLogin, userPassword).IsFound && isRunning)
                {
                    controller.DisplayMessage("Wrong login or password", 1000);
                }
            }
        }
    }
}
