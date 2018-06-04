using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity
{
    [TestClass]
    public class MeasureObjectTests : DomainObjectTests<MeasureObject, MeasureDbRecord>
    {
        protected override MeasureObject getRandomTestObject()
        {
            createdWithNullArg = new MeasureObject(null);
            dbRecordType = typeof(MeasureDbRecord);
            return GetRandom.Object<MeasureObject>();
        }
    }
}




