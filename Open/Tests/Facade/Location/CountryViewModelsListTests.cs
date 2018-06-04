using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Location;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {

    [TestClass] public class CountryViewModelsListTests : ObjectTests<CountryViewModelsList> {
        protected override CountryViewModelsList getRandomTestObject() {
            var l = new CountryObjectsList(null, null);
            SetRandom.Values(l);
            return new CountryViewModelsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewModelsList(null));
        }

    }
}



