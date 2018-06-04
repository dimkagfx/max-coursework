using System.Linq;
using Open.Aids;
using Open.Data.Money;
namespace Open.Infra.Money {
    public static class CountryCurrenciesDbTableInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.CountryCurrencies.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();

            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;

                var x = new CountryCurrencyDbRecord();
                x.CountryID = r.ThreeLetterISORegionName;
                x.CurrencyID = r.ISOCurrencySymbol;

                c.CountryCurrencies.Add(x);
            }

            c.SaveChanges();
        }
    }
}




