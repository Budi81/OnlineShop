using System;

namespace OnlineShop.BusinessLayer
{
    public class Shop
    {
        bool isRunning = true;

        private IDatabase database;

        private IControler controler;

        public Shop(IDatabase database, IControler controler)
        {
            this.database = database;
            this.controler = controler;
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
            throw new NotImplementedException();
        }

        private void ShowProduct(Product product)
        {
            throw new NotImplementedException();
        }

        private void ShowAllCustomers()
        {
            throw new NotImplementedException();
        }

        private void ShowCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        private void ShowAllOrders()
        {
            throw new NotImplementedException();
        }

        private void FindOrder(Order order)
        {
            throw new NotImplementedException();
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
                    switch (controler.UserChoice())
                    {
                        case 1:
                            ShowAllOrders();
                            
                            break;
                        case 2:
                            

                            break;

                        default:
                            controler.DisplayError("Wrong choice!", 1000);

                            break;
                    }

                }
                else
                {
                    switch (controler.UserChoice())
                    {
                        case 1:

                            break;
                        default:
                            controler.DisplayError("Wrong choice!", 1000);

                            break;
                    }

                }
            }
        }













    }
}
