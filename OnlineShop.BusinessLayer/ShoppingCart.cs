using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class ShoppingCart
    {
        Dictionary<Product, int> products;

        decimal countPrice;

        public Dictionary<Product, int> Products { get => products; set => products = value; }
        
        public decimal CountPrice { get => countPrice; private set => countPrice = value; }

        void AddToChart(Product product)
        {
            throw new NotImplementedException();
        }

        void RemoveFromChart(Product product)
        {
            throw new NotImplementedException();
        }

        void ClearChart()
        {
            throw new NotImplementedException();
        }
    }
}
