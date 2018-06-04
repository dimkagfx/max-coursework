using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {
    [TestClass]
    public class GeographicAddressObjectTests : DomainObjectTests<GeographicAddressObject, GeographicAddressDbRecord> {
        protected override GeographicAddressObject getRandomTestObject() {
            createdWithNullArg = new GeographicAddressObject(null);
            dbRecordType = typeof(GeographicAddressDbRecord);
            return GetRandom.Object<GeographicAddressObject>();
        }
        [TestMethod] public void RegisteredTelecomDevicesTest() {
            Assert.IsNotNull(obj.RegisteredTelecomDevices);
            Assert.IsInstanceOfType(obj.RegisteredTelecomDevices,
                typeof(IReadOnlyList<TelecomAddressObject>));
        }

        [TestMethod] public void RegisteredTelecomDeviceTest() {
            var device = GetRandom.Object<TelecomAddressObject>();
            Assert.IsFalse(obj.RegisteredTelecomDevices.Contains(device));
            obj.RegisteredTelecomDevice(device);
            Assert.IsTrue(obj.RegisteredTelecomDevices.Contains(device));
        }
        [TestMethod] public void CountryTest() {
            Assert.AreEqual(obj.Country.DbRecord, obj.DbRecord.Country);
        }
        [TestMethod] public void WhenCreatedWithNullArgumentsTest() {
            obj = new GeographicAddressObject(null);
            Assert.AreEqual(obj.Country.DbRecord, obj.DbRecord.Country);
        }
    }
}

