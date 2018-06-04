using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {
    [TestClass] public class TelecomDeviceRegistrationObjectFactoryTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TelecomDeviceRegistrationObjectFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<TelecomDeviceRegistrationDbRecord>();
            var address = new GeographicAddressObject(r.Address);
            var device = new TelecomAddressObject(r.Device);

            var o = TelecomDeviceRegistrationObjectFactory.Create(address, device, r.ValidFrom,
                r.ValidTo);

            Assert.AreEqual(o.DbRecord.ValidFrom, r.ValidFrom);
            Assert.AreEqual(o.DbRecord.ValidTo, r.ValidTo);
            Assert.AreEqual(o.Address.DbRecord, r.Address);
            Assert.AreEqual(o.Device.DbRecord, r.Device);
            Assert.AreEqual(o.DbRecord.AddressID, r.Address.ID);
            Assert.AreEqual(o.DbRecord.DeviceID, r.Device.ID);
            Assert.AreEqual(o.DbRecord.Address, r.Address);
            Assert.AreEqual(o.DbRecord.Device, r.Device);
        }

        [TestMethod] public void CreateWithNullArgumentsTest() {

            var o = TelecomDeviceRegistrationObjectFactory.Create(null, null);

            Assert.AreEqual(o.DbRecord.ValidFrom, DateTime.MinValue);
            Assert.AreEqual(o.DbRecord.ValidTo, DateTime.MaxValue);
            Assert.AreEqual(o.Address.DbRecord, o.DbRecord.Address);
            Assert.AreEqual(o.Device.DbRecord, o.DbRecord.Device);
            Assert.AreEqual(o.DbRecord.AddressID, Constants.Unspecified);
            Assert.AreEqual(o.DbRecord.DeviceID, Constants.Unspecified);
        }

    }
}




