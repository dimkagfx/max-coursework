using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
namespace Open.Tests.Data.Location {
    [TestClass] public class TelecomAddressDbRecordTests : ObjectTests<TelecomAddressDbRecord> {
        protected override TelecomAddressDbRecord getRandomTestObject() {
            return GetRandom.Object<TelecomAddressDbRecord>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressDbRecord), obj.GetType().BaseType);
        }
        [TestMethod] public void NationalDirectDialingPrefixTest() {
            testReadWriteProperty(() => obj.NationalDirectDialingPrefix,
                x => obj.NationalDirectDialingPrefix = x);
        }
        [TestMethod] public void DeviceTest() {
            testReadWriteProperty(() => obj.Device, x => obj.Device = x);
        }
    }
}



