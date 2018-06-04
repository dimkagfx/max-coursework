using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class UnitDbRecordTests : ObjectTests<UnitDbRecord> {
        protected override UnitDbRecord getRandomTestObject() {
            return GetRandom.Object<UnitDbRecord>();
        }
        [TestMethod] public void IsInstanceOfMetric() {
            Assert.AreEqual(typeof(MetricDbRecord), obj.GetType().BaseType);
        }
    }
}



