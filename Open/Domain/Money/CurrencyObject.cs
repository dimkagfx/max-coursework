using System.Collections.Generic;
using Open.Core;
using Open.Data.Money;
using Open.Domain.Common;
using Open.Domain.Location;
namespace Open.Domain.Money {
    public sealed class CurrencyObject : MetricObject<CurrencyDbRecord> {
        private readonly List<CountryObject> usedInCountries;
        public CurrencyObject(CurrencyDbRecord r) : base(r ?? new CurrencyDbRecord()) {
            usedInCountries = new List<CountryObject>();
        }
        public IReadOnlyList<CountryObject> UsedInCountries => usedInCountries.AsReadOnly();
        public void UsedInCountry(CountryObject countryObject) {
            if (countryObject is null) return;
            if (countryObject.DbRecord.ID == Constants.Unspecified) return;
            if (usedInCountries.Find(x => x.DbRecord.ID == countryObject.DbRecord.ID) != null)
                return;
            usedInCountries.Add(countryObject);
        }
    }

}




