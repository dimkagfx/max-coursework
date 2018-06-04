using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class MeasureDbRecordTests : ObjectTests<MeasureDbRecord> {
        protected override MeasureDbRecord getRandomTestObject() {
            return GetRandom.Object<MeasureDbRecord>();
        }
        [TestMethod] public void IsInstanceOfMetric() {
            Assert.AreEqual(typeof(MetricDbRecord), obj.GetType().BaseType);
        }
    }
}



