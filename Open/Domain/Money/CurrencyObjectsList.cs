using System.Collections.Generic;
using Open.Core;
using Open.Data.Money;
namespace Open.Domain.Money {
    public class CurrencyObjectsList : PaginatedList<CurrencyObject> {
        public CurrencyObjectsList(IEnumerable<CurrencyDbRecord> items, RepositoryPage page) :
            base(page) {
            if (items is null) return;
            foreach (var dbRecord in items) { Add(new CurrencyObject(dbRecord)); }
        }
    }
}

