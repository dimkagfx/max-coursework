using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {
    [TestClass] public class AddressObjectFactoryTests : BaseTests {
        private const string u = Constants.Unspecified;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(AddressObjectFactory);
        }

        [TestMethod] public void CreateEmailTest() {
            var r = GetRandom.Object<EmailAddressDbRecord>();
            var o = AddressObjectFactory.CreateEmail(r.ID, r.Address, r.ValidFrom, r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(EmailAddressObject));
            testVariables(o.DbRecord, r.ID, r.Address, r.ValidFrom, r.ValidTo);
        }
        private void testVariables(AddressDbRecord o, string id, string adr, DateTime vFrom,
            DateTime vTo, string city = u, string region = u, string zip = u) {
            Assert.AreEqual(id, o.ID);
            Assert.AreEqual(adr, o.Address);
            Assert.AreEqual(vFrom, o.ValidFrom);
            Assert.AreEqual(vTo, o.ValidTo);
            Assert.AreEqual(city, o.CityOrAreaCode);
            Assert.AreEqual(region, o.RegionOrStateOrCountryCode);
            Assert.AreEqual(zip, o.ZipOrPostCodeOrExtension);
        }
        [TestMethod] public void CreateWebTest() {
            var r = GetRandom.Object<WebPageAddressDbRecord>();
            var o = AddressObjectFactory.CreateWeb(
                r.ID,
                r.Address,
                r.ValidFrom,
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(WebAddressObject));
            testVariables(o.DbRecord, r.ID, r.Address, r.ValidFrom, r.ValidTo);
        }
        [TestMethod] public void CreateDeviceTest() {
            var r = GetRandom.Object<TelecomAddressDbRecord>();
            var o = AddressObjectFactory.CreateDevice(
                r.ID,
                r.RegionOrStateOrCountryCode,
                r.CityOrAreaCode,
                r.Address,
                r.ZipOrPostCodeOrExtension,
                r.NationalDirectDialingPrefix,
                r.Device,
                r.ValidFrom,
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(TelecomAddressObject));
            testVariables(o.DbRecord, r.ID, r.Address, r.ValidFrom, r.ValidTo, r.CityOrAreaCode,
                r.RegionOrStateOrCountryCode, o.DbRecord.ZipOrPostCodeOrExtension);
            Assert.AreEqual(r.NationalDirectDialingPrefix, o.DbRecord.NationalDirectDialingPrefix);
            Assert.AreEqual(r.Device, o.DbRecord.Device);
        }
        [TestMethod] public void CreateAddressTest() {
            var r = GetRandom.Object<GeographicAddressDbRecord>();
            var o = AddressObjectFactory.CreateAddress(
                r.ID, 
                r.Address, 
                r.CityOrAreaCode, 
                r.RegionOrStateOrCountryCode, 
                r.ZipOrPostCodeOrExtension, 
                r.CountryID,
                r.ValidFrom, 
                r.ValidTo);
            Assert.IsInstanceOfType(o, typeof(GeographicAddressObject));
            testVariables(o.DbRecord, r.ID, r.Address, r.ValidFrom, r.ValidTo, r.CityOrAreaCode,
                r.RegionOrStateOrCountryCode, o.DbRecord.ZipOrPostCodeOrExtension);
            Assert.AreEqual(r.CountryID, o.DbRecord.CountryID);
        }
        [TestMethod] public void CreateTest() {
            void test<T>(AddressDbRecord r) {
                var o = AddressObjectFactory.Create(r);
                Assert.IsInstanceOfType(o, typeof(T));
            }
            test<WebAddressObject>(GetRandom.Object<WebPageAddressDbRecord>());
            test<EmailAddressObject>(GetRandom.Object<EmailAddressDbRecord>());
            test<TelecomAddressObject>(GetRandom.Object<TelecomAddressDbRecord>());
            test<GeographicAddressObject>(GetRandom.Object<GeographicAddressDbRecord>());
            test<GeographicAddressObject>(GetRandom.Object<AddressDbRecord>());
            test<GeographicAddressObject>(null);
        }
    }
}
