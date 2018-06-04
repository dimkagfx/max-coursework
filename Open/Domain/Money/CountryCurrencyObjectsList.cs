using System.Collections.Generic;
using Open.Core;
using Open.Data.Money;
namespace Open.Domain.Money {
    public class CountryCurrencyObjectsList : PaginatedList<CountryCurrencyObject> {
        public CountryCurrencyObjectsList(IEnumerable<CountryCurrencyDbRecord> items,
            RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new CountryCurrencyObject(dbRecord)); }
        }
    }
}

