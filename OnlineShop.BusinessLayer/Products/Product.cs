using OnlineShop.BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public abstract class Product
    {       
        private int stock;
        
        private decimal price;

        private string productName;

        private ProductType type;

        public Product(int productId, string productName, decimal price, int stock, ProductType type)
        {
            this.ProductId = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
            Type = type;
        }

        public int ProductId { get; }
        public string ProductName { get => productName; private set => productName = value; }
        public decimal Price { get => price; private set => price = value; }
        public int Stock { get => stock; private set => stock = value; }
        public ProductType Type { get => type; private set => type = value; }
        
        public abstract List<ProductAttribute> GetAttributes();

        public abstract Product WithId(int newId);
    }
}
