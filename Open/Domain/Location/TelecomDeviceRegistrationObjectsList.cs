using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;

namespace Open.Domain.Location {

    public class
        TelecomDeviceRegistrationObjectsList : PaginatedList<TelecomDeviceRegistrationObject> {
        public TelecomDeviceRegistrationObjectsList(
            IEnumerable<TelecomDeviceRegistrationDbRecord> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new TelecomDeviceRegistrationObject(dbRecord)); }
        }
    }
}


