using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class ShoppingCart
    {
        private Dictionary<Product, int> products;

        private decimal countPrice;

        public Dictionary<Product, int> Products { get => products; private set => products = value; }

        public decimal CountPrice { get => countPrice; private set => countPrice = value; }

        public void AddToChart(Product product, int quantity)
        {
            products.Add(product, quantity);
            Count();
        }

        public void RemoveFromChart(Product product)
        {
            products.Remove(product);
            Count();
        }

        public void ClearChart()
        {
            products.Clear();
            Count();
        }

        public void Count()
        {
            foreach (KeyValuePair<Product, int> keyValues in products)
            {
                countPrice += keyValues.Key.Price * keyValues.Value;
            }
        }
    }
}