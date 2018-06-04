using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Data.Location;
using Open.Domain.Common;
namespace Open.Tests.Domain.Common {
    [TestClass]
    public class
        UniqueObjectTests : DomainObjectTests<UniqueObject<CountryDbRecord>, CountryDbRecord> {
        class testClass : UniqueObject<CountryDbRecord> {
            public testClass(CountryDbRecord dbRecord) : base(dbRecord) { }
        }
        protected override UniqueObject<CountryDbRecord> getRandomTestObject() {
            createdWithNullArg = new testClass(null);
            dbRecordType = typeof(UniqueDbRecord);
            return GetRandom.Object<testClass>();
        }

    }
}



