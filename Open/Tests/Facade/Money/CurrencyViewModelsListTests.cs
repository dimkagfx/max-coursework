








using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Money;
using Open.Facade.Location;
using Open.Facade.Money;
namespace Open.Tests.Facade.Money {
    [TestClass] public class CurrencyViewModelsListTests : ObjectTests<CurrencyViewModelsList> {
        protected override CurrencyViewModelsList getRandomTestObject() {
            var l = new CurrencyObjectsList(null, null);
            SetRandom.Values(l);
            return new CurrencyViewModelsList(l);
        }

        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewModelsList(null));
        }

    }
}

