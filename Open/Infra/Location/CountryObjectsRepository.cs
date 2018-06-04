using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Infra.Location {

    public class CountryObjectsRepository : ObjectsRepository<CountryObject, CountryDbRecord>,
        ICountryObjectsRepository {


        public CountryObjectsRepository(SentryDbContext c) : base(c?.Countries, c) { }
        protected internal override CountryObject createObject(CountryDbRecord r) {
            return new CountryObject(r);
        }
        protected internal override PaginatedList<CountryObject> createList(
            List<CountryDbRecord> l, RepositoryPage p) {
            return new CountryObjectsList(l, p);
        }
    }
}



