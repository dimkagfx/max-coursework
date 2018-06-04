using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;
namespace Open.Tests.Domain.Money
{
    [TestClass]
    public class CountryCurrencyObjectsListTests : DomainObjectsListTests<CountryCurrencyObjectsList, CountryCurrencyObject>
    {
        protected override CountryCurrencyObjectsList getRandomTestObject()
        {
            createWithNullArgs = new CountryCurrencyObjectsList(null, null);
            var l = GetRandom.Object<List<CountryCurrencyDbRecord>>();
            return new CountryCurrencyObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}



