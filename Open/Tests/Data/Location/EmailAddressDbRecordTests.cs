using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
namespace Open.Tests.Data.Location {
    [TestClass] public class EmailAddressDbRecordTests : ObjectTests<EmailAddressDbRecord> {
        protected override EmailAddressDbRecord getRandomTestObject() {
            return GetRandom.Object<EmailAddressDbRecord>();
        }

        [TestMethod] public void IsInstanceOfAddressDbRecord() {
            Assert.AreEqual(typeof(AddressDbRecord), typeof(EmailAddressDbRecord).BaseType);
        }

    }
}
