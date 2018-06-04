using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {
    [TestClass] public class TelecomAddressViewModelTests : ObjectTests<TelecomAddressViewModel> {
        protected override TelecomAddressViewModel getRandomTestObject() {
            return GetRandom.Object<TelecomAddressViewModel>();
        }
        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressViewModel));
        }
        [TestMethod] public void CountryCodeTest() {
            testReadWriteProperty(()=>obj.CountryCode, x => obj.CountryCode = x);
        }
        [TestMethod] public void AreaCodeTest() {
            testReadWriteProperty(() => obj.AreaCode, x => obj.AreaCode = x);
        }
        [TestMethod] public void NumberTest() {
            testReadWriteProperty(() => obj.Number, x => obj.Number = x);
        }
        [TestMethod] public void ExtensionTest() {
            testReadWriteProperty(() => obj.Extension, x => obj.Extension = x);
        }
        [TestMethod] public void NationalDirectDialingPrefixTest() {
            testReadWriteProperty(() => obj.NationalDirectDialingPrefix, x => obj.NationalDirectDialingPrefix = x);
        }
        [TestMethod] public void DeviceTypeTest() {
            testReadWriteProperty(() => obj.DeviceType, x => obj.DeviceType = x);
        }
        [TestMethod] public void RegisteredInAddressesTest() {
            Assert.IsInstanceOfType(obj.RegisteredInAddresses,
                typeof(List<GeographicAddressViewModel>));
            var name =
                GetMember.Name<TelecomAddressViewModel>(x => x.RegisteredInAddresses);
            Assert.IsTrue(IsReadOnly.Property<TelecomAddressViewModel>(name));
        }
        [TestMethod]
        public void ToStringTest()
        {
            var s = obj.Number;
            if (obj.AreaCode != Constants.Unspecified) s = $"{obj.AreaCode} {s}";
            if (obj.NationalDirectDialingPrefix != Constants.Unspecified) s = $"({obj.NationalDirectDialingPrefix}){s}";
            if (obj.CountryCode != Constants.Unspecified) s = $"{obj.CountryCode} {s}";
            if (obj.Extension != Constants.Unspecified) s = $"{s} ext. {obj.Extension}";
            Assert.AreEqual(s, obj.ToString());
        }
    }
}




