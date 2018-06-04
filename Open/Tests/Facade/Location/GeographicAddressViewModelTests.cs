using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {
    [TestClass]
    public class GeographicAddressViewModelTests : ObjectTests<GeographicAddressViewModel> {

        protected override GeographicAddressViewModel getRandomTestObject() {
            return GetRandom.Object<GeographicAddressViewModel>();
        }

        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressViewModel));
        }

        [TestMethod] public void AadressLineTest() {
            testReadWriteProperty(() => obj.AddressLine, x => obj.AddressLine = x);
        }

        [TestMethod] public void CityTest() {
            testReadWriteProperty(() => obj.City, x => obj.City = x);
        }

        [TestMethod] public void CountryTest() {
            testReadWriteProperty(() => obj.Country, x => obj.Country = x);
        }

        [TestMethod] public void RegionOrStateTest() {
            testReadWriteProperty(() => obj.RegionOrState, x => obj.RegionOrState = x);
        }

        [TestMethod] public void ZipOrPostalCodeTest() {
            testReadWriteProperty(() => obj.ZipOrPostalCode, x => obj.ZipOrPostalCode = x);
        }

        [TestMethod] public void RegisteredTelecomAddressesTest() {
            Assert.IsInstanceOfType(obj.RegisteredTelecomAddresses,
                typeof(List<TelecomAddressViewModel>));
            var name =
                GetMember.Name<GeographicAddressViewModel>(x => x.RegisteredTelecomAddresses);
            Assert.IsTrue(IsReadOnly.Property<GeographicAddressViewModel>(name));
        }

        [TestMethod] public void ToStringTest() {
            var s = obj.AddressLine;
            if (obj.City != Constants.Unspecified) s = $"{s} {obj.City}";
            if (obj.RegionOrState != Constants.Unspecified) s = $"{s} {obj.RegionOrState}";
            if (obj.ZipOrPostalCode != Constants.Unspecified) s = $"{s} {obj.ZipOrPostalCode}";
            if (obj.Country != Constants.Unspecified) s = $"{s} {obj.Country}";
            Assert.AreEqual(s, obj.ToString());
        }

    }
}






