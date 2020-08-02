using OnlineShop.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OnlineShop.ConsoleInterface
{
    public class ConsoleController : IController
    {
        public int UserChoiceInt(string message)
        {
            bool output;
            do
            {
                Console.WriteLine(message);
                Console.Write("> ");
                output = int.TryParse(Console.ReadLine(), out int result);
                return result;
            } while (!output);
        }

        public string UserInputString(string message)
        {
            Console.Write(message);
            string result = Console.ReadLine();
            return result;
        }

        public void DisplayMessage(string massage, int milliseconds)
        {
            Console.WriteLine(massage);
            Thread.Sleep(milliseconds);
        }

        public void WriteOutData(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public string GetPassword()
        {
            Console.Write("Password: ");
            string password = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                password += key.KeyChar;
            }
            Console.WriteLine();
            return password;
        }

        public void DisplayCustomer(Customer customer)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Customer Id: {customer.CustomerId}\n" +
                $"Name: {customer.Name} {customer.Surname}\n" +
                $"email: {customer.Email}\n" +
                $"Address:: {customer.Address}");
            Console.WriteLine(new string('-', 30));
        }

        public void DisplayOrder(Order order)
        {
            Console.Clear();
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Order Id: {order.OrderId}\n" +
                $"Customer: id{order.Customer.CustomerId} {order.Customer.Name} {order.Customer.Surname}\n" +
                $"email: {order.Customer.Email}\n" +
                $"Address: {order.Customer.Address}\n" +
                $"Amount to pay: {order.OrderCount}\n" +
                $"Date of order: {order.DateOfOrder}");
            DisplayProductInOrder(order);
            Console.WriteLine(new string('-', 30));
        }

        public void DisplayProduct(Product product)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Product Id: {product.ProductId}\n" +
                $"Product: {product.ProductName} amount: {product.Stock}\n" +
                $"Product type: {product.Type}");
            DisplayAttributes(product);
        }

        private void DisplayProductInOrder(Order order)
        {
            foreach (KeyValuePair<Product, int> productAmount in order.Products)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Product Id: {productAmount.Key.ProductId}\n" +
                    $"Product: {productAmount.Key.ProductName} amount: {productAmount.Value}\n" +
                    $"Product type: {productAmount.Key.Type}");
                DisplayAttributes(productAmount.Key);
            }
        }

        private void DisplayAttributes(Product product)
        {
            List<ProductAttribute> productAttributes = product.GetAttributes();
            Console.WriteLine(new string('-', 50));
            foreach (var attribute in productAttributes)
            {
                Console.WriteLine($"{attribute.Name}: {attribute.Value}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}