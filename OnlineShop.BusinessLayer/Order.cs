using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class Order
    {
        Dictionary<string, int> products;

        float orderCount;

        int OrderId;

        bool isSend;
    }
}
