using System;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer
{
    public class Order
    {
        private int orderId;
        private Customer customer;

        private decimal orderCount;

        private Dictionary<Product, int> products;

        private DateTime dateOfOrder;

        private bool isSend;

        public Order(int orderId,
            Customer customer,
            decimal orderCount,
            Dictionary<Product, int> products,
            DateTime dateOfOrder,
            bool isSend)
        {
            OrderId = orderId;
            Customer = customer;
            OrderCount = orderCount;
            Products = products;
            IsSend = isSend;
        }

        public Dictionary<Product, int> Products { get => products; private set => products = value; }
        public decimal OrderCount { get => orderCount; private set => orderCount = value; }
        public int OrderId { get => orderId; private set => orderId = value; }
        public bool IsSend { get => isSend; private set => isSend = value; }
        public Customer Customer { get => customer; private set => customer = value; }
        public DateTime DateOfOrder { get => dateOfOrder; set => dateOfOrder = value; }

        public static Order FromShoppingCart(ShoppingCart shoppingCart, Customer customer)
        {
            decimal orderCount = 0;
            foreach (KeyValuePair<Product, int> keyValuePair in shoppingCart.Products)
            {
                orderCount += keyValuePair.Key.Price * keyValuePair.Value;
            }
            int orderId = 0;

            DateTime dateOfOrder = DateTime.UtcNow;

            Order newOrder = new Order(orderId, customer, orderCount, shoppingCart.Products, dateOfOrder, false);

            return newOrder;
        }

        public Order WithId(int newId)
        {
            return new Order(newId, this.Customer, this.OrderCount, this.Products, this.dateOfOrder, this.isSend);
        }
    }
}