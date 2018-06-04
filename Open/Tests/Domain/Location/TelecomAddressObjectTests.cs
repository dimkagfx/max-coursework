using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {
    [TestClass]
    public class TelecomAddressObjectTests : DomainObjectTests<TelecomAddressObject, TelecomAddressDbRecord> {
        protected override TelecomAddressObject getRandomTestObject() {
            createdWithNullArg = new TelecomAddressObject(null);
            dbRecordType = typeof(TelecomAddressDbRecord);
            return GetRandom.Object<TelecomAddressObject>();
        }
        [TestMethod] public void RegisteredInAddressesTest() {
            Assert.IsNotNull(obj.RegisteredInAddresses);
            Assert.IsInstanceOfType(obj.RegisteredInAddresses,
                typeof(IReadOnlyList<GeographicAddressObject>));
        }

        [TestMethod] public void RegisteredInAddressTest() {
            var address = GetRandom.Object<GeographicAddressObject>();
            Assert.IsFalse(obj.RegisteredInAddresses.Contains(address));
            obj.RegisteredInAddress(address);
            Assert.IsTrue(obj.RegisteredInAddresses.Contains(address));
        }
    }
}





