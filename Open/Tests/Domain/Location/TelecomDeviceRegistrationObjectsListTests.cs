using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;

namespace Open.Tests.Domain.Location {
    [TestClass]
    public class TelecomDeviceRegistrationObjectsListTests : DomainObjectsListTests<
        TelecomDeviceRegistrationObjectsList, TelecomDeviceRegistrationObject> {

        protected override TelecomDeviceRegistrationObjectsList getRandomTestObject() {
            createWithNullArgs = new TelecomDeviceRegistrationObjectsList(null, null);
            var l = GetRandom.Object<List<TelecomDeviceRegistrationDbRecord>>();
            return new TelecomDeviceRegistrationObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}





