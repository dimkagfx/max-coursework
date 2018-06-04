using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {

    [TestClass]
    public class
        TelecomDeviceRegistrationObjectTests : ObjectTests<TelecomDeviceRegistrationObject> {

        protected override TelecomDeviceRegistrationObject getRandomTestObject() {
            return GetRandom.Object<TelecomDeviceRegistrationObject>();
        }

        [TestMethod] public void AddressTest() {
            Assert.AreEqual(obj.Address.DbRecord, obj.DbRecord.Address);
        }

        [TestMethod] public void DeviceTest() {
            Assert.AreEqual(obj.Device.DbRecord, obj.DbRecord.Device);
        }

        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new TelecomDeviceRegistrationObject(null);
            Assert.AreEqual(obj.Address.DbRecord, obj.DbRecord.Address);
            Assert.AreEqual(obj.Device.DbRecord, obj.DbRecord.Device);
        }

    }
}






