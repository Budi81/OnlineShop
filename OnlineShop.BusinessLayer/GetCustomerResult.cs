using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public class GetCustomerResult
    {
        private Customer customer;

        private GetCustomerResult(bool isFound, Customer foundEntry)
        {
            IsFound = isFound;
            customer = foundEntry;
        }

        public GetCustomerResult(Customer foundEntry)
            : this(true, foundEntry)
        {

        }

        public GetCustomerResult()
            : this(false, null)
        {

        }

        public bool IsFound { get; private set; }

        public Customer FoundEntry
        {
            get
            {
                if (this.IsFound == true)
                {
                    return this.customer;
                }
                else
                {
                    throw new InvalidOperationException("Wrong login or password!");
                }
            }
            private set
            {
                this.customer = value;
            }
        }
    }
}
