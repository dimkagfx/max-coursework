using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Infra.Location;
namespace Open.Tests.Infra.Location {
    [TestClass]
    public class
        TelecomDeviceRegistrationObjectsRepositoryTests : TelecomDeviceRegistrationDbTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TelecomDeviceRegistrationObjectsRepository);
        }

        [TestMethod] public void CanCreate() {
            Assert.IsNotNull(new TelecomDeviceRegistrationObjectsRepository(null));
        }
        [TestMethod] [ExpectedException(typeof(NotImplementedException))]
        public async Task GetObjectTest() {
            var id = GetRandom.String();
            await repository.GetObject(id);
        }
        private static void validateRegistration(TelecomDeviceRegistrationDbRecord actual,
            TelecomDeviceRegistrationDbRecord expected) {
            Assert.AreEqual(actual.AddressID, expected.AddressID);
            Assert.AreEqual(actual.DeviceID, expected.DeviceID);
            Assert.AreEqual(actual.ValidFrom, expected.ValidFrom);
            Assert.AreEqual(actual.ValidTo, expected.ValidTo);
        }
        [TestMethod] public async Task AddObjectTest() {
            var o = GetRandom.Object<TelecomDeviceRegistrationObject>();
            var r = db.TelecomDeviceRegistrations.FirstOrDefault(x => isThis(x, o));
            Assert.IsNull(r);
            await repository.AddObject(o);
            r = db.TelecomDeviceRegistrations.FirstOrDefault(x => isThis(x, o));
            validateRegistration(r, o.DbRecord);
        }
        private bool isThis(TelecomDeviceRegistrationDbRecord record
            , TelecomDeviceRegistrationObject obj) {
            if (record.AddressID != obj.DbRecord.AddressID) return false;
            if (record.DeviceID != obj.DbRecord.DeviceID) return false;
            return true;
        }
        [TestMethod] public async Task UpdateObjectTest() {
            var o = GetRandom.Object<TelecomDeviceRegistrationObject>();
            await repository.AddObject(o);
            o.DbRecord.ValidFrom = GetRandom.DateTime(null, DateTime.Now.AddYears(-10));
            o.DbRecord.ValidTo = GetRandom.DateTime(DateTime.Now.AddYears(10));
            await repository.UpdateObject(o);
            Assert.AreEqual(count + 1, db.TelecomDeviceRegistrations.Count());
            var r = db.TelecomDeviceRegistrations.FirstOrDefault(x => isThis(x, o));
            validateRegistration(r, o.DbRecord);
        }
        [TestMethod] public async Task DeleteObjectTest() {
            var c = count;
            Assert.AreEqual(c, db.TelecomDeviceRegistrations.Count());
            foreach (var e in db.TelecomDeviceRegistrations) {
                await repository.DeleteObject(new TelecomDeviceRegistrationObject(e));
                Assert.AreEqual(--c, db.TelecomDeviceRegistrations.Count());
            }
        }

        [TestMethod] public void LoadAddressesTest() {
            Assert.Inconclusive();
        }

        [TestMethod] public void LoadDevicesTest() {
            Assert.Inconclusive();
        }

    }
}


