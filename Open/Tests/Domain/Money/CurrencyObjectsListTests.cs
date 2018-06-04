using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;

namespace Open.Tests.Domain.Money {
    [TestClass] public class CurrencyObjectsListTests : DomainObjectsListTests<CurrencyObjectsList, CurrencyObject> {
        protected override CurrencyObjectsList getRandomTestObject() {
            createWithNullArgs = new CurrencyObjectsList(null, null);
            var l = GetRandom.Object<List<CurrencyDbRecord>>();
            return new CurrencyObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}



