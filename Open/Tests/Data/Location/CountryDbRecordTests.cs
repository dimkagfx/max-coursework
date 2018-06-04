using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
namespace Open.Tests.Data.Location {
    [TestClass] public class CountryDbRecordTests : ObjectTests<CountryDbRecord> {
        protected override CountryDbRecord getRandomTestObject() {
            return GetRandom.Object<CountryDbRecord>();
        }
        [TestMethod] public void BaseTypeIsIdentifiedDbRecord() {
            Assert.AreEqual(typeof(IdentifiedDbRecord), typeof(CountryDbRecord).BaseType);
        }

        [TestMethod] public void ContainsTest() {
            Assert.IsFalse(obj.Contains(GetRandom.String()));
            Assert.IsTrue(obj.Contains(string.Empty));
            Assert.IsTrue(obj.Contains(null));
            Assert.IsTrue(obj.Contains(obj.ID));
            Assert.IsTrue(obj.Contains(obj.Name));
            Assert.IsTrue(obj.Contains(obj.Code));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidFrom.Month.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.ValidTo.Month.ToString()));
        }
    }
}




