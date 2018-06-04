using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
namespace Open.Tests.Data.Location {
    [TestClass] public class WebPageAddressDbRecordTests : ObjectTests<WebPageAddressDbRecord> {
        protected override WebPageAddressDbRecord getRandomTestObject() {
            return GetRandom.Object<WebPageAddressDbRecord>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressDbRecord), obj.GetType().BaseType);
        }

    }
}

