using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class Shop
    {
        private bool _isRunning = true;
        private bool _logIn = false;

        private string _userLogin = null;
        private string _userPassword = null;

        private IDatabase _database;

        private IController _controller;

        public Shop(IDatabase database, IController controller)
        {
            this._database = database;
            this._controller = controller;
        }

        private int DisplayStartingMenu()
        {
            int userChoice = _controller.UserChoiceInt(
                "Welcome to E-Shop!\n" +
                "What do you want to do?\n" +
                "  (1) Login\n" +
                "  (2) Sign in\n" +
                "  (3) Exit");
            return userChoice;
        }

        private void UserLogin()
        {
            _userLogin = _controller.GetInput("Login: ");
            _userPassword = _controller.GetPassword();
        }

        public bool IsEmployee()
        {
            return (_userLogin == Employee.Login && _userPassword == Employee.Password);
        }

        private void ShowAllProducts()
        {
            List<Product> products = _database.GetAllProducts();
            foreach (var product in products)
            {
                _controller.WriteOutData(
                    $"ID: {product.ProductId}, Type: {product.Type}, " +
                    $"Name: {product.ProductName}, Price: {product.Price}, " +
                    $"In stock: {product.Stock}");
            }
        }

        private void ShowProduct(string productName)
        {
            List<Product> products = _database.GetProduct(productName);
            Product product = products[0];
            _controller.WriteOutData(
                $"ID: {product.ProductId}, Type: {product.Type}, " +
                $"Name: {product.ProductName}, Price: {product.Price}, " +
                $"In stock: {product.Stock}");
        }

        private void ShowAllCustomers()
        {
            List<Customer> allCustomers = _database.GetAllCustomers();
            foreach (var customer in allCustomers)
            {
                _controller.DisplayCustomer(customer);
            }
        }

        private void FindCustomers(string name, string surname)
        {
            List<Customer> customers = _database.GetCustomers(name, surname);

            foreach (var customer in customers)
            {
                _controller.DisplayCustomer(customer);
            };
        }

        private void ShowAllOrders()
        {
            List<Order> orders = _database.GetAllOrders();
            foreach (var order in orders)
            {
                _controller.WriteOutData(
                    $"ID: {order.OrderId}, Date: {order.DateOfOrder}, " +
                    $"Product: {order.Products}, Count: {order.OrderCount}, " +
                    $"Customer: {order.Customer}, Sent: {order.IsSend}");
            }
        }

        private void FindOrder(string orderId)
        {
            Order order = _database.GetOrder(orderId);
            _controller.DisplayOrder(order);
        }

        private void CreateAccount()
        {
            int id = 0;
            string name = _controller.GetInput("Name: ");
            string surname = _controller.GetInput("Surname: ");
            string address = _controller.GetInput("Address: ");
            string email = _controller.GetInput("E-mail: ");
            _userLogin = email;
            string password = _controller.GetPassword();

            Customer newCustomer = new Customer(id, name, surname, address, email, password);
            _database.AddCustomer(newCustomer);
        }

        private void ShowCustomerOrders(Customer customer)
        {
            List<Order> orders = _database.GetCustomerOrders(customer);
            foreach (var order in orders)
            {
                _controller.WriteOutData(
                    $"ID: {order.OrderId}, Date: {order.DateOfOrder}, " +
                    $"Product: {order.Products}, Count: {order.OrderCount}, " +
                    $"Sent: {order.IsSend}");
            }
        }

        public void ProgramRunning()
        {
            while (_isRunning)
            {
                int userChoice = DisplayStartingMenu();
                bool restart = false;
                _userLogin = null;
                _userPassword = null;

                switch (userChoice)
                {
                    case 1:
                        UserLogin();
                        break;

                    case 2:
                        CreateAccount();
                        restart = true;
                        break;

                    case 3:
                        _controller.DisplayMessage("Ending program", 1000);
                        _isRunning = false;

                        break;

                    default:
                        _controller.DisplayMessage("Wrong choice!", 1000);
                        break;
                }

                if (restart) 
                    continue;

                Customer customer = _database.GetCustomer(_userLogin, _userPassword);

                if (IsEmployee() && _isRunning)
                {
                    _logIn = true;
                    while (_logIn)
                    {
                        switch (_controller.UserChoiceInt(
                            "Hi Mark!" +
                            "What do you want to do today?\n" +
                            "  (1) Show all orders\n" +
                            "  (2) Show all customers\n" +
                            "  (3) Show all products\n" +
                            "  (4) Find customer\n" +
                            "  (5) Find order\n" +
                            "  (6) Logout"))
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
                                {
                                    string userName = _controller.UserInputString("Customer name: ");
                                    string userSurname = _controller.UserInputString("Customer Surname: ");
                                    FindCustomers(userName, userSurname);
                                    break;
                                }

                            case 5:
                                string orderId = _controller.UserInputString("Order id: ");
                                FindOrder(orderId);

                                break;

                            case 6:
                                _controller.DisplayMessage("Logging out..", 1000);
                                _logIn = false;

                                break;

                            default:
                                _controller.DisplayMessage("Wrong choice!", 1000);

                                break;
                        }
                    }
                }
                else if (customer != null && _isRunning)
                {
                    _logIn = true;

                    while (_logIn)
                    {
                        switch (_controller.UserChoiceInt(
                            $"Hello {customer.Name}!\n" +
                            $"How may I help you?\n" +
                            "  (1) Go Shopping\n" +
                            "  (2) Show my order\n" +
                            "  (3) Show my cart\n" +
                            "  (4) Show all shop products\n" +
                            "  (5) Add product to your cart\n" +
                            "  (6) Place order\n" +
                            "  (7) Logout"))
                        {
                            case 1:
                                ShowAllProducts();

                                break;

                            case 2:
                                ShowCustomerOrders(customer);

                                break;

                            case 3:
                                _controller.DisplayCart(customer.Chart);

                                break;

                            case 4:
                                ShowAllProducts();

                                break;

                            case 5:
                                var productId =
                                    _controller.UserChoiceInt("What is the product ID you want to add to your cart?");
                                var numberOfItems = _controller.UserChoiceInt("How much of it you want to buy?");
                                var selectedProduct = _database.GetProduct(productId);
                                customer.Chart.AddToChart(selectedProduct, numberOfItems);
                                _controller.DisplayMessage($"{selectedProduct.ProductName} added to cart!", 700);
                                
                                break;

                            case 6:
                                var customerOrder = Order.FromShoppingCart(customer);
                                _database.AddOrder(customerOrder);
                                _controller.DisplayMessage("Your order has been placed!", 700);

                                break;

                            case 7:
                                _controller.DisplayMessage("Logging out..", 1000);
                                _logIn = false;

                                break;

                            default:
                                _controller.DisplayMessage("Wrong choice!", 1000);

                                break;
                        }
                    }
                }
                else if (customer == null && _isRunning)
                {
                    _controller.DisplayMessage("Wrong login or password", 1000);
                }
            }
        }
    }
}