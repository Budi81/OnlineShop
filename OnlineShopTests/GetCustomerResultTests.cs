using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OnlineShop.BusinessLayer;

namespace OnlineShopTests
{
    [TestFixture]
    public class GetCustomerResultTests
    {
        [Test]
        public void FoundEntryTest()
        {
            var customer = new Customer(1, "Jan", "Kowalski", "Miodowa", "jan@kowalski.pl", "hashed");
            var getCustomerResult = new GetCustomerResult(customer);
            var result = getCustomerResult.FoundEntry;
            Assert.AreEqual(customer, result);
        }

        [Test]
        public void FoundEntryTestFail()
        {
            var exception = new InvalidOperationException("Wrong login or password!");
            var getCustomerResult = new GetCustomerResult();
            Assert.That(() => getCustomerResult.FoundEntry, Throws.InvalidOperationException.And.Message.EqualTo("Wrong login or password!"));
        }
    }
}
