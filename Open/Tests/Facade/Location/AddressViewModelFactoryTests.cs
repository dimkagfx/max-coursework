using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Domain.Location;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {
    [TestClass] public class AddressViewModelFactoryTests : BaseTests {
        private const string u = Constants.Unspecified;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(AddressViewModelFactory);
        }
        [TestMethod] public void CreateTest() {
            var v = AddressViewModelFactory.Create(null) as GeographicAddressViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, u);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
            Assert.AreEqual(v.AddressLine, u);
            Assert.AreEqual(v.City, u);
            Assert.AreEqual(v.RegionOrState, u);
            Assert.AreEqual(v.ZipOrPostalCode, u);
            Assert.AreEqual(v.Country, u);
            Assert.AreEqual(v.RegisteredTelecomAddresses.Count, 0);
        }

        [TestMethod] public void CreateWebAddressViewModelTest() {
            var o = GetRandom.Object<WebAddressObject>();
            var v = AddressViewModelFactory.Create(o) as WebPageAddressViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Url, o.DbRecord.Address);
        }
        [TestMethod] public void CreateEMailAddressViewModelTest() {
            var o = GetRandom.Object<EmailAddressObject>();
            var v = AddressViewModelFactory.Create(o) as EMailAddressViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.EmailAddress, o.DbRecord.Address);
        }
        [TestMethod] public void CreateGeographicAddressViewModelTest() {
            var o = GetRandom.Object<GeographicAddressObject>();
            var v = AddressViewModelFactory.Create(o) as GeographicAddressViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.AddressLine, o.DbRecord.Address);
            Assert.AreEqual(v.City, o.DbRecord.CityOrAreaCode);
            Assert.AreEqual(v.RegionOrState, o.DbRecord.RegionOrStateOrCountryCode);
            Assert.AreEqual(v.ZipOrPostalCode, o.DbRecord.ZipOrPostCodeOrExtension);
            Assert.AreEqual(v.Country, o.DbRecord.Country.ID);
            Assert.AreEqual(v.RegisteredTelecomAddresses.Count, o.RegisteredTelecomDevices.Count);
        }
        [TestMethod] public void CreateTelecomAddressViewModelTest() {
            var o = GetRandom.Object<TelecomAddressObject>();
            var v = AddressViewModelFactory.Create(o) as TelecomAddressViewModel;
            Assert.IsNotNull(v);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.Number, o.DbRecord.Address);
            Assert.AreEqual(v.AreaCode, o.DbRecord.CityOrAreaCode);
            Assert.AreEqual(v.CountryCode, o.DbRecord.RegionOrStateOrCountryCode);
            Assert.AreEqual(v.Extension, o.DbRecord.ZipOrPostCodeOrExtension);
            Assert.AreEqual(v.NationalDirectDialingPrefix, o.DbRecord.NationalDirectDialingPrefix);
            Assert.AreEqual(v.DeviceType, o.DbRecord.Device);
            Assert.AreEqual(v.RegisteredInAddresses.Count, o.RegisteredInAddresses.Count);
        }

        [TestMethod] public void CreateWithExtremumDatesTest() {
            var o = GetRandom.Object<WebAddressObject>();
            o.DbRecord.ValidFrom = DateTime.MinValue;
            o.DbRecord.ValidTo = DateTime.MaxValue;
            var v = AddressViewModelFactory.Create(o);
            Assert.AreEqual(v.ID, o.DbRecord.ID);
            Assert.AreEqual(v.ValidFrom, null);
            Assert.AreEqual(v.ValidTo, null);
        }
    }
}
