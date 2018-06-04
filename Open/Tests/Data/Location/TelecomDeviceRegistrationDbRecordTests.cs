
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
namespace Open.Tests.Data.Location {

    [TestClass]
    public class
        TelecomDeviceRegistrationDbRecordTests : ObjectTests<TelecomDeviceRegistrationDbRecord> {
        protected override TelecomDeviceRegistrationDbRecord getRandomTestObject() {
            return GetRandom.Object<TelecomDeviceRegistrationDbRecord>();
        }
        [TestMethod] public void DeviceIDTest() {
            testReadWriteProperty(() => obj.DeviceID, x => obj.DeviceID = x);
            testNullEmptyAndWhitespaceCases(() => obj.DeviceID, x => obj.DeviceID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void AddressIDTest() {
            testReadWriteProperty(() => obj.AddressID, x => obj.AddressID = x);
            testNullEmptyAndWhitespaceCases(() => obj.AddressID, x => obj.AddressID = x,
                () => Constants.Unspecified);
        }
        [TestMethod] public void DeviceTest() {
            testReadWriteProperty(() => obj.Device, x => obj.Device = x);
            obj.Device = null;
            Assert.IsNull(obj.Device);
        }
        [TestMethod] public void AddressTest() {
            testReadWriteProperty(() => obj.Address, x => obj.Address = x);
            obj.Address = null;
            Assert.IsNull(obj.Address);
        }

    }
}


