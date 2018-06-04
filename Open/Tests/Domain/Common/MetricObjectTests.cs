using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Money;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass] public class MetricObjectTests : DomainObjectTests<MetricObject<CurrencyDbRecord>, CurrencyDbRecord> {
        class testClass : MetricObject<CurrencyDbRecord> {
            public testClass(CurrencyDbRecord dbRecord) : base(dbRecord) { }
        }
        protected override MetricObject<CurrencyDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(MetricDbRecord);
            return GetRandom.Object<testClass>();
        }

    }
}


