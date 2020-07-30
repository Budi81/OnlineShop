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

        bool IsEmployee()
        {
            throw new NotImplementedException();
        }

        void ShowAllProducts()
        {
            throw new NotImplementedException();
        }

        void ShowProduct(Product product)
        {
            throw new NotImplementedException();
        }

        void ShowAllCustomers()
        {
            throw new NotImplementedException();
        }

        void ShowCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        void ShowAllOrders()
        {
            throw new NotImplementedException();
        }

        void ShowOrder(Order order)
        {
            throw new NotImplementedException();
        }

        void CreateAccount()
        {
            throw new NotImplementedException();
        }

        void ProgramRunning()
        {
            while (isRunning)
            {

            }
        }













    }
}
