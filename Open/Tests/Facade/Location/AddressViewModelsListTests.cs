using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Facade.Location;
namespace Open.Tests.Facade.Location {
    [TestClass] public class AddressViewModelsListTests : ObjectTests<AddressViewModelsList> {
        protected override AddressViewModelsList getRandomTestObject() {
            var l = new AddressObjectsList(getRandomAddressDbRecordsList(),
                GetRandom.Object<RepositoryPage>());
            SetRandom.Values(l);
            return new AddressViewModelsList(l);
        }
        private IEnumerable<AddressDbRecord> getRandomAddressDbRecordsList() {
            var l = new List<AddressDbRecord>();
            for (var i = 0; i < GetRandom.UInt8(5, 10); i++) {
                var x = i % 4;
                if (x == 0) l.Add(GetRandom.Object<WebPageAddressDbRecord>());
                if (x == 1) l.Add(GetRandom.Object<EmailAddressDbRecord>());
                if (x == 2) l.Add(GetRandom.Object<TelecomAddressDbRecord>());
                if (x == 3) l.Add(GetRandom.Object<GeographicAddressDbRecord>());
            }

            return l;
        }
        [TestMethod] public void CanCreateWithNullArgumentTest() {
            Assert.IsNotNull(new CountryViewModelsList(null));
        }

    }
}

