using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class Order
    {
        private int OrderId;

        private Customer customer;
        
        private decimal orderCount;

        private Dictionary<Product, int> products;

        private DateTime dateOfOrder;

        private bool isSend;

        public Order(int orderId1, Customer customer, decimal orderCount, Dictionary<Product, int> products, DateTime dateOfOrder, bool isSend)
        {
            OrderId1 = orderId1;
            Customer = customer;
            OrderCount = orderCount;
            Products = products;
            IsSend = isSend;
        }

        public Dictionary<Product, int> Products { get => products; private set => products = value; }
        public decimal OrderCount { get => orderCount; private set => orderCount = value; }
        public int OrderId1 { get => OrderId; private set => OrderId = value; }
        public bool IsSend { get => isSend; private set => isSend = value; }
        public Customer Customer { get => customer; private set => customer = value; }
        public DateTime DateOfOrder { get => dateOfOrder; set => dateOfOrder = value; }

        public static Order fromShoppingCart(ShoppingCart shoppingCart)
        {
            decimal orderCount = 0;
            foreach (KeyValuePair<Product, int> keyValuePair in shoppingCart.Products)
            {
                orderCount += keyValuePair.Key.Price * keyValuePair.Value;
            }

            int orderId = 0;
            Order newOrder = new Order(0, orderCount, shoppingCart.Products, false);

            return newOrder;
        } 
    }
}
