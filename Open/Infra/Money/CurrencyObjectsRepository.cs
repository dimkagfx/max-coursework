using System.Collections.Generic;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Money;
namespace Open.Infra.Money {
    public class CurrencyObjectsRepository : ObjectsRepository<CurrencyObject, CurrencyDbRecord>,
        ICurrencyObjectsRepository {


        public CurrencyObjectsRepository(SentryDbContext c) : base(c?.Currencies, c) { }
        protected internal override CurrencyObject createObject(CurrencyDbRecord r) {
            return new CurrencyObject(r);
        }
        protected internal override PaginatedList<CurrencyObject> createList(
            List<CurrencyDbRecord> l, RepositoryPage p) {
            return new CurrencyObjectsList(l, p);
        }
    }
}

