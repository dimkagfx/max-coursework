using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity
{
    [TestClass]
    public class UnitObjectTests : DomainObjectTests<UnitObject, UnitDbRecord>
    {
        protected override UnitObject getRandomTestObject()
        {
            createdWithNullArg = new UnitObject(null);
            dbRecordType = typeof(UnitDbRecord);
            return GetRandom.Object<UnitObject>();
        }
    }
}

