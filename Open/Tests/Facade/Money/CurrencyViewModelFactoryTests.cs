using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Money;
using Open.Facade.Money;

namespace Open.Tests.Facade.Money {
    [TestClass] public class CurrencyViewModelFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrencyViewModelFactory);
        }

        [TestMethod] public void CreateTest() {
            var o = GetRandom.Object<CurrencyObject>();
            var v = CurrencyViewModelFactory.Create(o);
            Assert.AreEqual(v.Name, o.DbRecord.Name);
            Assert.AreEqual(v.ValidFrom, o.DbRecord.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.DbRecord.ValidTo);
            Assert.AreEqual(v.IsoCode, o.DbRecord.ID);
            Assert.AreEqual(v.Symbol, o.DbRecord.Code);
        }
    }
}


