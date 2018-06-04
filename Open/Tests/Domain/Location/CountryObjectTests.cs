using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Location;
using Open.Data.Location;
using Open.Domain.Money;
namespace Open.Tests.Domain.Location {

    [TestClass]
    public class CountryObjectTests : DomainObjectTests<CountryObject, CountryDbRecord> {

        protected override CountryObject getRandomTestObject() {
            createdWithNullArg = new CountryObject(null);
            dbRecordType = typeof(CountryDbRecord);
            return GetRandom.Object<CountryObject>();
        }

        [TestMethod] public void CurrenciesInUseTest() {
            Assert.IsNotNull(obj.CurrenciesInUse);
            Assert.IsInstanceOfType(obj.CurrenciesInUse, typeof(IReadOnlyList<CurrencyObject>));
        }

        [TestMethod] public void CurrencyInUseTest() {
            var currency = GetRandom.Object<CurrencyObject>();
            Assert.IsFalse(obj.CurrenciesInUse.Contains(currency));
            obj.CurrencyInUse(currency);
            Assert.IsTrue(obj.CurrenciesInUse.Contains(currency));
        }
    }
}



