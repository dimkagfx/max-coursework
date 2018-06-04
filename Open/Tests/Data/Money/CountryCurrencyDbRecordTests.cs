using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
namespace Open.Tests.Data.Money {
    [TestClass] public class CountryCurrencyDbRecordTests : ObjectTests<CountryCurrencyDbRecord> {
        protected override CountryCurrencyDbRecord getRandomTestObject() {
            return GetRandom.Object<CountryCurrencyDbRecord>();
        }
        [TestMethod] public void CountryIDTest() {
            testReadWriteProperty(() => obj.CountryID, x => obj.CountryID = x);
            testNullEmptyAndWhitespaceCases(() => obj.CountryID, x => obj.CountryID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void CurrencyIDTest() {
            testReadWriteProperty(() => obj.CurrencyID, x => obj.CurrencyID = x);
            testNullEmptyAndWhitespaceCases(() => obj.CurrencyID, x => obj.CurrencyID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void CountryTest() {
            testReadWriteProperty(() => obj.Country, x => obj.Country = x);
            obj.Country = null;
            Assert.IsNull(obj.Country);
        }
        [TestMethod] public void CurrencyTest() {
            testReadWriteProperty(() => obj.Currency, x => obj.Currency = x);
            obj.Currency = null;
            Assert.IsNull(obj.Currency);
        }
    }
}





