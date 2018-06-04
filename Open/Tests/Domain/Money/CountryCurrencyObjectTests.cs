using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Money;
namespace Open.Tests.Domain.Money {
    [TestClass]
    public class CountryCurrencyObjectTests : ObjectTests<CountryCurrencyObject> {
        protected override CountryCurrencyObject getRandomTestObject() {
            return GetRandom.Object<CountryCurrencyObject>();
        }
        [TestMethod] public void CountryTest() {
            Assert.AreEqual(obj.Country.DbRecord, obj.DbRecord.Country);
        }
        [TestMethod] public void CurrencyTest() {
            Assert.AreEqual(obj.Currency.DbRecord, obj.DbRecord.Currency);
        }
        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new CountryCurrencyObject(null);
            Assert.AreEqual(obj.Country.DbRecord, obj.DbRecord.Country);
            Assert.AreEqual(obj.Currency.DbRecord, obj.DbRecord.Currency);
        }
    }
}





