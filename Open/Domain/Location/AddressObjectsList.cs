using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;
namespace Open.Domain.Location
{
    public class AddressObjectsList : PaginatedList<IAddressObject>
    {
        public AddressObjectsList(IEnumerable<AddressDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(AddressObjectFactory.Create(dbRecord));
            }
        }
    }
}




