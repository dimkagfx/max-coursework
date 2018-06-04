using System.Linq;
using Open.Aids;
using Open.Domain.Location;
namespace Open.Infra.Location {

    public static class CountriesDbTableInitializer {

        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Countries.Any()) return;
            var regions = SystemRegionInfo.GetRegionsList();
            foreach (var r in regions) {
                if (!SystemRegionInfo.IsCountry(r)) continue;
                var e = CountryObjectFactory.Create(r);
                c.Countries.Add(e.DbRecord);
            }
            c.SaveChanges();
        }
    }
}







