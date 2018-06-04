using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Tests.Domain.Location {
    [TestClass] public class CountryObjectsListTests : DomainObjectsListTests<CountryObjectsList, CountryObject> {
        protected override CountryObjectsList getRandomTestObject() {
            createWithNullArgs = new CountryObjectsList(null, null);
            var l = GetRandom.Object<List<CountryDbRecord>>();
            return new CountryObjectsList(l, GetRandom.Object<RepositoryPage>());
        }
    }
}

