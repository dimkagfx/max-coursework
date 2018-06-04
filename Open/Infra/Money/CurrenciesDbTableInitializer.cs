using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Domain.Money;
namespace Open.Infra.Money {
    public static class CurrenciesDbTableInitializer {

        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Currencies.Any()) return;
            var list = new List<string>();
            var regions = SystemRegionInfo.GetRegionsList();
            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                if (list.Contains(r.ISOCurrencySymbol)) continue;
                var e = CurrencyObjectFactory.Create(r);
                c.Currencies.Add(e.DbRecord);
                list.Add(r.ISOCurrencySymbol);
            }
            c.SaveChanges();
        }
    }
}

