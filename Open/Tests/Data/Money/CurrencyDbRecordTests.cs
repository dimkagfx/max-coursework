using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Money;
namespace Open.Tests.Data.Money {
    [TestClass] public class CurrencyDbRecordTests : ObjectTests<CurrencyDbRecord> {
        protected override CurrencyDbRecord getRandomTestObject() {
            return GetRandom.Object<CurrencyDbRecord>();
        }

        [TestMethod] public void IsInstanceOfMetric() {
            Assert.AreEqual(typeof(MetricDbRecord), obj.GetType().BaseType);
        }
    }
}



