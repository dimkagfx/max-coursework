using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Domain.Common;
using Open.Domain.Location;
namespace Open.Tests.Domain
{
    [TestClass] public abstract class DomainObjectTests<TObject, TRecord> : ObjectTests<TObject> 
        where TObject: TemporalObject<TRecord> 
        where TRecord: TemporalDbRecord, new() {
        protected TObject createdWithNullArg;
        protected Type dbRecordType;

        [TestMethod] public void DbRecordTest() {
            Assert.IsNotNull(obj.DbRecord);
            Assert.IsInstanceOfType(obj.DbRecord, dbRecordType);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(createdWithNullArg.DbRecord);
            Assert.IsInstanceOfType(createdWithNullArg.DbRecord, dbRecordType);
        }
        [TestMethod]
        public void DbRecordIsReadOnlyTest()
        {
            var name = GetMember.Name<CountryObject>(x => x.DbRecord);
            Assert.IsTrue(IsReadOnly.Field<CountryObject>(name));
        }
    }
}



