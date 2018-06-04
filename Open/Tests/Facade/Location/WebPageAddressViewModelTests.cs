using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {
    [TestClass] public class WebPageAddressViewModelTests : ObjectTests<WebPageAddressViewModel> {

        protected override WebPageAddressViewModel getRandomTestObject() {
            return GetRandom.Object<WebPageAddressViewModel>();
        }

        [TestMethod] public void IsAddressViewModelTest() {
            Assert.AreEqual(obj.GetType().BaseType, typeof(AddressViewModel));
        }

        [TestMethod] public void UrlTest() {
            testReadWriteProperty(() => obj.Url, x => obj.Url = x);
        }
        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(obj.Url, obj.ToString());
        }

    }
}

