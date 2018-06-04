using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Common;
using Open.Facade.Location;
using Open.Facade.Money;
namespace Open.Tests.Facade.Location {

    [TestClass]
    public class CountryViewModelTests : ViewModelTests<CountryViewModel, NamedViewModel> {
        protected override CountryViewModel getRandomTestObject() {
            return GetRandom.Object<CountryViewModel>();
        }

        [TestMethod] public void Alpha3CodeTest() {
            testReadWriteProperty(() => obj.Alpha3Code, x => obj.Alpha3Code = x);
        }
        [TestMethod] public void Alpha2CodeTest() {
            testReadWriteProperty(() => obj.Alpha2Code, x => obj.Alpha2Code = x);
        }
        [TestMethod] public void CurrenciesInUseTest() {
            Assert.IsInstanceOfType(obj.CurrenciesInUse, typeof(List<CurrencyViewModel>));
            var name = GetMember.Name<CountryViewModel>(x => x.CurrenciesInUse);
            Assert.IsTrue(IsReadOnly.Property<CountryViewModel>(name));
        }
    }
}






