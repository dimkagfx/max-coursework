using Open.Infra.Location;
using Open.Infra.Money;
namespace Open.Infra
{
    public static class DbTablesInitializer
    {
        public static void Initialize(SentryDbContext dbContext) {
            CountriesDbTableInitializer.Initialize(dbContext);
            CurrenciesDbTableInitializer.Initialize(dbContext);
            CountryCurrenciesDbTableInitializer.Initialize(dbContext);
            AddressDbTableInitializer.Initialize(dbContext);
        }
    }
}


