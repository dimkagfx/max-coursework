using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass] public class TemporalObjectTests : DomainObjectTests<TemporalObject<CountryDbRecord> , CountryDbRecord> {
        class testClass : TemporalObject<CountryDbRecord> {
            public testClass(CountryDbRecord dbRecord) : base(dbRecord) { }
        }
        protected override TemporalObject<CountryDbRecord> getRandomTestObject() {
            dbRecordType = typeof(TemporalDbRecord);
            createdWithNullArg = new testClass(null);
            return GetRandom.Object<testClass>();
        }
    }
}

