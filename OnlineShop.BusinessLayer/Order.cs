using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class Order
    {
        private int OrderId;
        
        private float orderCount;

        private Dictionary<string, int> products;

        private bool isSend;

        public Order(int orderId1, float orderCount, Dictionary<string, int> products, bool isSend)
        {
            OrderId1 = orderId1;
            OrderCount = orderCount;
            Products = products;
            IsSend = isSend;
        }

        public Dictionary<string, int> Products { get => products; private set => products = value; }
        public float OrderCount { get => orderCount; private set => orderCount = value; }
        public int OrderId1 { get => OrderId; private set => OrderId = value; }
        public bool IsSend { get => isSend; private set => isSend = value; }
    }
}
