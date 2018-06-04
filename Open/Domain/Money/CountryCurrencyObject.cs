
using Open.Data.Location;
using Open.Data.Money;
using Open.Domain.Common;
using Open.Domain.Location;
namespace Open.Domain.Money {
    public class CountryCurrencyObject : TemporalObject<CountryCurrencyDbRecord> {
        public readonly CountryObject Country;
        public readonly CurrencyObject Currency;
        public CountryCurrencyObject(CountryCurrencyDbRecord dbRecord) : base(dbRecord) {
            DbRecord.Country = DbRecord.Country ?? new CountryDbRecord();
            DbRecord.Currency = DbRecord.Currency ?? new CurrencyDbRecord();

            Country = new CountryObject(DbRecord.Country);
            Currency = new CurrencyObject(DbRecord.Currency);
        }
    }
}



