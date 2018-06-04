using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {

    [TestClass]
    public class WebAddressObjectTests : DomainObjectTests<WebAddressObject, WebPageAddressDbRecord> {
        protected override WebAddressObject getRandomTestObject() {
            createdWithNullArg = new WebAddressObject(null);
            dbRecordType = typeof(WebPageAddressDbRecord);
            return GetRandom.Object<WebAddressObject>();
        }
    }
}


