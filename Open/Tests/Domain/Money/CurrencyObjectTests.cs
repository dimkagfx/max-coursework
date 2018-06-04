using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Money;
using Open.Domain.Location;
using Open.Domain.Money;
namespace Open.Tests.Domain.Money {
    [TestClass]
    public class CurrencyObjectTests : DomainObjectTests<CurrencyObject, CurrencyDbRecord> {
        protected override CurrencyObject getRandomTestObject() {
            createdWithNullArg = new CurrencyObject(null);
            dbRecordType = typeof(CurrencyDbRecord);
            return GetRandom.Object<CurrencyObject>();
        }

        [TestMethod] public void UsedInCountriesTest() {
            Assert.IsNotNull(obj.UsedInCountries);
            Assert.IsInstanceOfType(obj.UsedInCountries, typeof(IReadOnlyList<CountryObject>));
        }

        [TestMethod] public void UsedInCountryTest() {
            var country = GetRandom.Object<CountryObject>();
            Assert.IsFalse(obj.UsedInCountries.Contains(country));
            obj.UsedInCountry(country);
            Assert.IsTrue(obj.UsedInCountries.Contains(country));
        }

    }
}




