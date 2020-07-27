using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public abstract class Product
    {
        protected readonly int productId;
        private int stock;
        
        private float price;

        private string productName;

        protected Product(int productId, string productName, float price, int stock)
        {
            this.productId = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public int ProductId { get => productId; }
        public string ProductName { get => productName; private set => productName = value; }
        public float Price { get => price; private set => price = value; }
        public int Stock { get => stock; private set => stock = value; }
    }
}
