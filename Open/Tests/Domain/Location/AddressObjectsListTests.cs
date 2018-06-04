using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location
{
    [TestClass]
    public class AddressObjectsListTests : DomainObjectsListTests<AddressObjectsList, IAddressObject>
    {
        protected override AddressObjectsList getRandomTestObject()
        {
            createWithNullArgs = new AddressObjectsList(null, null);
            var l = getAddressDbRecordsList();
            return new AddressObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
        private IEnumerable<AddressDbRecord> getAddressDbRecordsList() {
            var l = new List<AddressDbRecord>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                var x = i % 4;
                if (x == 0 ) l.Add(GetRandom.Object<WebPageAddressDbRecord>());
                if (x == 1) l.Add(GetRandom.Object<EmailAddressDbRecord>());
                if (x == 2) l.Add(GetRandom.Object<TelecomAddressDbRecord>());
                if (x == 3) l.Add(GetRandom.Object<GeographicAddressDbRecord>());
            }

            return l;
        }
    }
}


