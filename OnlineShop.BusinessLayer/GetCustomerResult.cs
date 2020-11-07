using System;

namespace OnlineShop.BusinessLayer
{
    public class GetCustomerResult
    {

        private GetCustomerResult(bool isFound, Customer foundEntry)
        {
            IsFound = isFound;
            FoundEntry = foundEntry;
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

        public Customer FoundEntry { get; private set; }
    }
}