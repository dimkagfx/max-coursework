using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Money;
using Open.Domain.Location;
using Open.Domain.Money;
namespace Open.Infra.Money {
    public class CountryCurrencyObjectsRepository : ICountryCurrencyObjectsRepository {
        private readonly DbSet<CountryCurrencyDbRecord> dbSet;
        private readonly DbContext db;
        public CountryCurrencyObjectsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.CountryCurrencies;
        }
        public Task<CountryCurrencyObject> GetObject(string id) {
            throw new NotImplementedException();
        }
        public async Task AddObject(CountryCurrencyObject o) {
            dbSet.Add(o.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(CountryCurrencyObject o) {
            dbSet.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(CountryCurrencyObject o) {
            dbSet.Remove(o.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task LoadCountries(CurrencyObject currency) {
            if (currency is null) return;
            var id = currency.DbRecord?.ID ?? string.Empty;
            var countries = await dbSet.Include(x => x.Country).Where(x => x.CurrencyID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in countries)
                currency.UsedInCountry(new CountryObject(c.Country));
        }
        public async Task LoadCurrencies(CountryObject country) {
            if (country is null) return;
            var id = country.DbRecord?.ID ?? string.Empty;
            var currencies = await dbSet.Include(x => x.Currency).Where(x => x.CountryID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in currencies)
                country.CurrencyInUse(new CurrencyObject(c.Currency));
        }
    }
}


