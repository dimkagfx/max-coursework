using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Location;
using Open.Domain.Money;
namespace Open.Tests.Domain.Money {

    [TestClass] public class CountryCurrencyObjectFactoryTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CountryCurrencyObjectFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<CountryCurrencyDbRecord>();
            var country = new CountryObject(r.Country);
            var currency = new CurrencyObject(r.Currency);

            var o = CountryCurrencyObjectFactory.Create(country, currency, r.ValidFrom, r.ValidTo);

            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Currency.DbRecord, r.Currency);
            Assert.AreEqual(o.Country.DbRecord, r.Country);
            Assert.AreEqual(o.DbRecord.CountryID, r.Country.ID);
            Assert.AreEqual(o.DbRecord.CurrencyID, r.Currency.ID);
            Assert.AreEqual(o.DbRecord.Country, r.Country);
            Assert.AreEqual(o.DbRecord.Currency, r.Currency);
        }

        [TestMethod] public void CreateWithNullArgumentsTest() {

            var o = CountryCurrencyObjectFactory.Create(null, null);

            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Currency.DbRecord, o.DbRecord.Currency);
            Assert.AreEqual(o.Country.DbRecord, o.DbRecord.Country);
            Assert.AreEqual(o.DbRecord.CountryID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.CurrencyID, Constants.Unspecified);
        }

    }
}
