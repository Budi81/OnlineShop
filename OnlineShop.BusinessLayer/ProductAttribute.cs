using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class ProductAttribute
    {
        string name;

        string value;

        public ProductAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get => name; private set => name = value; }
        
        public string Value { get => value; private set => this.value = value; }
    }
}
