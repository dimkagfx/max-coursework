using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
namespace Open.Tests.Data.Location {
    [TestClass] public class AddressDbRecordTests : ObjectTests<AddressDbRecord> {
        class testClass : AddressDbRecord { }
        protected override AddressDbRecord getRandomTestObject() {
            return GetRandom.Object<testClass>();
        }
        [TestMethod] public void IsNotAbstract() {
            Assert.IsFalse(typeof(AddressDbRecord).IsAbstract);
        }
        [TestMethod] public void IsInstanceOfUniqueDbRecord() {
            Assert.AreEqual(typeof(UniqueDbRecord), typeof(AddressDbRecord).BaseType);
        }
        [TestMethod] public void AddressTest() {
            testReadWriteProperty(() => obj.Address, x => obj.Address = x);
        }
        [TestMethod] public void CityOrAreaCodeTest() {
            testReadWriteProperty(() => obj.CityOrAreaCode, x => obj.CityOrAreaCode = x);
        }
        [TestMethod] public void RegionOrStateOrCountryCodeTest() {
            testReadWriteProperty(() => obj.RegionOrStateOrCountryCode,
                x => obj.RegionOrStateOrCountryCode = x);
        }
        [TestMethod] public void ZipOrPostCodeOrExtensionTest() {
            testReadWriteProperty(() => obj.ZipOrPostCodeOrExtension,
                x => obj.ZipOrPostCodeOrExtension = x);
        }
    }
}


