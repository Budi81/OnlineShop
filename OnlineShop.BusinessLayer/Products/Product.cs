using OnlineShop.BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public abstract class Product
    {
        protected readonly int productId;
        
        private int stock;
        
        private decimal price;

        private string productName;

        protected Product(int productId, string productName, decimal price, int stock)
        {
            this.productId = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public int ProductId { get => productId; }
        public string ProductName { get => productName; private set => productName = value; }
        public decimal Price { get => price; private set => price = value; }
        public int Stock { get => stock; private set => stock = value; }

        public abstract ProductType GetType();
        
        public abstract List<ProductAttribute> GetAttributes();
    }
}
