
using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;
namespace Open.Tests.Domain.Money {
    [TestClass] public class CurrencyObjectFactoryTests : BaseTests {
        private CurrencyObject o;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(CurrencyObjectFactory);
        }
        [TestMethod] public void CreateTest() {
            var b = GetRandom.Object<CurrencyDbRecord>();
            o = CurrencyObjectFactory.Create(b.ID, b.Name, b.Code, b.ValidFrom, b.ValidTo);
            validateResults(b.ID, b.Name, b.Code, b.ValidFrom, b.ValidTo);
        }
        [TestMethod] public void CreateWithNullRegionInfoTest() {
            o = CurrencyObjectFactory.Create(null);
            validateResults();
        }
        [TestMethod] public void CreateWithRegionInfoTest() {
            var i = new RegionInfo("ee-EE");
            o = CurrencyObjectFactory.Create(i);
            validateResults(i.ISOCurrencySymbol, i.CurrencyEnglishName, i.CurrencySymbol);
        }
        private void validateResults(string i = Constants.Unspecified,
            string n = Constants.Unspecified, string c = Constants.Unspecified, DateTime? f = null,
            DateTime? t = null) {
            Assert.AreEqual(i, o.DbRecord.ID);
            Assert.AreEqual(n, o.DbRecord.Name);
            Assert.AreEqual(c, o.DbRecord.Code);
            Assert.AreEqual(f ?? DateTime.MinValue, o.DbRecord.ValidFrom);
            Assert.AreEqual(t ?? DateTime.MaxValue, o.DbRecord.ValidTo);
        }
    }
}


